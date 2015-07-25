using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using ScorePredict.Common.Models;
using ScorePredict.Core.Contracts;
using ScorePredict.Core.ViewModels.Abstract;
using ScorePredict.Services.Contracts;
using System.Windows.Input;
using Xamarin.Forms;
using System.Threading.Tasks;

namespace ScorePredict.Core.ViewModels
{
    public class RankingsPageViewModel : ScorePredictRootPageViewModel
    {
        private readonly IRankingService _rankingService;
        private readonly IReadUserSecurityService _readUserSecurityService;

        private ObservableCollection<RankingModel> _rankings;

        public ObservableCollection<RankingModel> Rankings
        {
            get { return _rankings; }
            private set
            {
                _rankings = value;
                OnPropertyChanged();
            }
        }

        public RankingsPageViewModel(IRankingService rankingService, IClearUserSecurityService clearUserSecurityService,
            IDialogService dialogService, IReadUserSecurityService readUserSecuritService, IKillApplication killApp)
            : base(clearUserSecurityService, dialogService, killApp)
        {
            _rankingService = rankingService;
            _readUserSecurityService = readUserSecuritService;
        }

        public async override void OnShow()
        {
            try
            {
                DialogService.ShowLoading("Loading Rankings...");
                await LoadRankingsAsync();
            }
            catch (Exception)
            {
                DialogService.Alert("Failed to load Rankings");
            }
            finally
            {
                DialogService.HideLoading();
            }
        }

        async Task LoadRankingsAsync()
        {
            var weekRankings = await _rankingService.GetCurrentWeekRankings();
            var userRanking = weekRankings.FirstOrDefault(x => x.UserId == _readUserSecurityService.ReadUser().UserId);
            if (userRanking != null)
                userRanking.IsCurrentUser = true;

            Rankings = new ObservableCollection<RankingModel>(weekRankings);
        }

        protected async Task Refresh()
        {
            try
            {
                DialogService.ShowLoading("Refreshing...");
                await LoadRankingsAsync();
            }
            catch
            {
                DialogService.Alert("Failed to reload Rankings. Please try again");
            }
            finally
            {
                DialogService.HideLoading();
            }
        }
    }
}
