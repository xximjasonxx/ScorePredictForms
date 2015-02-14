using System;
using System.Threading.Tasks;
using System.Windows.Input;
using ScorePredict.Core.Contracts;
using ScorePredict.Services;
using ScorePredict.Services.Contracts;
using Xamarin.Forms;

namespace ScorePredict.Core.ViewModels
{
    public class ThisWeekPageViewModel : ScorePredictBaseViewModel
    {
        public IThisWeekService ThisWeekService { get; private set; }

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

        public string PointsAwardedDisplay
        {
            get
            {
                return PointsAwarded == 1 ? "1pt" : string.Format("{0}pts", PointsAwarded);
            }
        }

        public string PredictionCountDisplay
        {
            get { return PredictionCount == 1 ? "1 prediction" : string.Format("{0} predictions", PredictionCount); }
        }

        public ThisWeekPageViewModel(IThisWeekService thisWeekService, IDialogService dialogService,
            IClearUserSecurityService clearUserSecurityService, INavigator navigator)
            : base(clearUserSecurityService, navigator, dialogService)
        {
            ThisWeekService = thisWeekService;
        }

        protected override async void Refresh()
        {
            await LoadWeekDataAsync();
        }

        public override async void OnShow()
        {
            await LoadWeekDataAsync();
        }

        private async Task LoadWeekDataAsync()
        {
            ShowProgress = true;
            try
            {
                var result = await ThisWeekService.GetCurrentWeekSummaryAsync();
                PointsAwarded = result.Points;
                PredictionCount = result.TotalPredictions;
                RankDisplay = string.Format("#{0} out of {1} user{2}",
                    result.Ranking, result.UserCount,
                    result.UserCount == 1 ? string.Empty : "s");
                WeekYearDisplay = string.Format("Week {0} {1}", result.WeekNumber, result.Year);
            }
            catch (Exception ex)
            {
                DialogService.Alert("An error occured getting Current week data");
            }
            finally
            {
                ShowProgress = false;
            }
        }
    }
}
