using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using ScorePredict.Common.Ex;
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
        public IBus MessageBus { get; private set; }
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

        public ThisWeekPageViewModel(IThisWeekService thisWeekService, IDialogService dialogService,
            IClearUserSecurityService clearUserSecurityService, IBus messageBus,
            IReadUserSecurityService readUserSecurityService, IKillApplication killApp)
            : base(clearUserSecurityService, dialogService, killApp)
        {
            ThisWeekService = thisWeekService;
            MessageBus = messageBus;
            ReadUserSecurityService = readUserSecurityService;
        }

        protected async Task Refresh()
        {
            try
            {
                DialogService.ShowLoading("Refreshing...");
                await LoadWeekDataAsync();
            }
            catch
            {
                DialogService.Alert("Failed to refresh this week data. Please try again");
            }
            finally
            {
                DialogService.HideLoading();
            }
        }

        public override async void OnShow()
        {
            MessageBus.ListenFor<LoginCompleteMessage>(LoadWeekData);
            if (ReadUserSecurityService.ReadUser() != null)
            {
                await LoadWeekDataAsync();
            }
        }

        private async void LoadWeekData()
        {
            await LoadWeekDataAsync();
        }

        private async Task LoadWeekDataAsync()
        {
            try
            {
                DialogService.ShowLoading("Loading This Week...");

                var result = await ThisWeekService.GetCurrentWeekSummaryAsync();
                PointsAwarded = result.Points;
                PredictionCount = result.TotalPredictions;
                RankDisplay = string.Format("You're ranked #{0} out of {1} user{2}",
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
                DialogService.HideLoading();
            }
        }
    }
}
