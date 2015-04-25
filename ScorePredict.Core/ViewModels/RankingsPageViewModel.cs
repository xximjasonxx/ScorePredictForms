using System;
using System.Collections.ObjectModel;
using System.Linq;
using ScorePredict.Common.Models;
using ScorePredict.Core.Contracts;
using ScorePredict.Core.ViewModels.Abstract;
using ScorePredict.Services.Contracts;

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
                ShowProgress = true;
                var weekRankings = await _rankingService.GetCurrentWeekRankings();
                var userRanking = weekRankings.FirstOrDefault(x => x.UserId == _readUserSecurityService.ReadUser().UserId);
                if (userRanking != null)
                    userRanking.IsCurrentUser = true;

                Rankings = new ObservableCollection<RankingModel>(weekRankings);
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
