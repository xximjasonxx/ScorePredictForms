using System;
using System.Threading.Tasks;
using System.Windows.Input;
using ScorePredict.Core.Contracts;
using ScorePredict.Core.MessageBus;
using ScorePredict.Core.MessageBus.Messages;
using ScorePredict.Core.ViewModels.Abstract;
using ScorePredict.Services;
using ScorePredict.Services.Contracts;
using Xamarin.Forms;

namespace ScorePredict.Core.ViewModels
{
    public class ThisWeekPageViewModel : ScorePredictRootPageViewModel
    {
        public IThisWeekService ThisWeekService { get; private set; }
        public IReadUserSecurityService ReadUserSecurityService { get; private set; }

        private int _pointsAwarded;
        public int PointsAwarded
        {
            get { return _pointsAwarded; }
            set
            {
                if (value != _pointsAwarded)
                {
                    _pointsAwarded = value;
                    OnPropertyChanged("PointsAwardedDisplay");
                }
            }
        }

        private int _predictionCount;
        public int PredictionCount
        {
            get { return _predictionCount; }
            set
            {
                if (value != _predictionCount)
                {
                    _predictionCount = value;
                    OnPropertyChanged("PredictionCountDisplay");
                }
            }
        }

        private string _rankDisplay;
        public string RankDisplay
        {
            get { return _rankDisplay; }
            set
            {
                if (value != _rankDisplay)
                {
                    _rankDisplay = value;
                    OnPropertyChanged();
                }
            }
        }

        private string _weekYearDisplay;
        public string WeekYearDisplay
        {
            get { return _weekYearDisplay; }
            set
            {
                if (value != _weekYearDisplay)
                {
                    _weekYearDisplay = value;
                    OnPropertyChanged();
                }
            }
        }

        private bool _noGames;
        public bool NoGames
        {
            get { return _noGames; }
            private set
            {
                if (_noGames != value)
                {
                    _noGames = value;
                    OnPropertyChanged();
                }
            }
        }

        public string PointsAwardedDisplay
        {
            get
            {
                return PointsAwarded == 1 ? "1pt" : string.Format("{0}pts", PointsAwarded);
            }
        }

        public string PredictionCountDisplay
        {
            get { return "You've made " + (PredictionCount == 1 ? "1 prediction" : string.Format("{0} predictions", PredictionCount)); }
        }

        public ICommand RefreshCommand { get { return new Command(Refresh); } }

        public ThisWeekPageViewModel(IThisWeekService thisWeekService, IDialogService dialogService,
            IClearUserSecurityService clearUserSecurityService,
            IReadUserSecurityService readUserSecurityService, IKillApplication killApp)
            : base(clearUserSecurityService, dialogService, killApp)
        {
            ThisWeekService = thisWeekService;
            ReadUserSecurityService = readUserSecurityService;
        }

        private async void Refresh()
        {
            try
            {
                ShowLoading("Refreshing...");
                await LoadWeekDataAsync();
            }
            catch
            {
                DialogService.Alert("Failed to refresh this week data. Please try again");
            }
            finally
            {
                HideLoading();
            }
        }

        public override async void OnShow()
        {
            if (IsLoaded) return;

            try
            {
                ShowLoading("Loading This Week...");
                await LoadWeekDataAsync();
            }
            catch
            {
                DialogService.Alert("Failed to load data for this week. Please refresh");
            }
            finally
            {
                HideLoading();
            }
        }

        private async Task LoadWeekDataAsync()
        {
            var result = await ThisWeekService.GetCurrentWeekSummaryAsync();
            PointsAwarded = result.Points;
            PredictionCount = result.TotalPredictions;
            RankDisplay = string.Format("You're ranked #{0} out of {1} user{2}",
                result.Ranking, result.UserCount,
                result.UserCount == 1 ? string.Empty : "s");
            WeekYearDisplay = string.Format("Week {0} {1}", result.WeekNumber, result.Year);
            NoGames = result.GamesCount == 0;

            IsLoaded = true;
        }
    }
}
