using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using ScorePredict.Common.Models;
using ScorePredict.Core.Contracts;
using ScorePredict.Core.ViewModels.Abstract;
using ScorePredict.Services.Contracts;
using Xamarin.Forms;

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

        public ICommand RefreshCommand { get { return new Command(Refresh); } }

        public RankingsPageViewModel(IRankingService rankingService, IClearUserSecurityService clearUserSecurityService,
            IDialogService dialogService, IReadUserSecurityService readUserSecuritService, IKillApplication killApp)
            : base(clearUserSecurityService, dialogService, killApp)
        {
            _rankingService = rankingService;
            _readUserSecurityService = readUserSecuritService;
        }

        public async override void OnShow()
        {
            if (IsLoaded) return;

            try
            {
                ShowLoading("Loading Rankings...");
                await LoadRankingsAsync();
                IsLoaded = true;
            }
            catch (Exception)
            {
                DialogService.Alert("Failed to load Rankings");
            }
            finally
            {
                HideLoading();
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

        private async void Refresh()
        {
            try
            {
                ShowLoading("Refreshing...");
                await LoadRankingsAsync();
            }
            catch
            {
                DialogService.Alert("Failed to reload Rankings. Please try again");
            }
            finally
            {
                HideLoading();
            }
        }
    }
}
