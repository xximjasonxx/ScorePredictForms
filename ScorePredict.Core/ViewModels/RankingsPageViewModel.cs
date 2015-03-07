using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ScorePredict.Common.Models;
using ScorePredict.Core.Contracts;
using ScorePredict.Services.Contracts;

namespace ScorePredict.Core.ViewModels
{
    public class RankingsPageViewModel : ScorePredictBaseViewModel
    {
        private readonly IRankingService _rankingService;

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
            INavigator navigator, IDialogService dialogService) : base(clearUserSecurityService, navigator, dialogService)
        {
            _rankingService = rankingService;
        }

        public async override void OnShow()
        {
            try
            {
                ShowProgress = true;
                Rankings = new ObservableCollection<RankingModel>(await _rankingService.GetCurrentWeekRankings());
            }
            catch (Exception ex)
            {
                DialogService.Alert("Failed to load Rankings");
            }
            finally
            {
                ShowProgress = false;
            }
        }
    }
}
