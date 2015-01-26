using System;
using ScorePredict.Services;
using ScorePredict.Services.Contracts;

namespace ScorePredict.Core.ViewModels
{
    public class ThisWeekPageViewModel : ViewModelBase
    {
        public IThisWeekService ThisWeekService { get; private set; }
        public IDialogService DialogService { get; private set; }

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

        public string PointsAwardedDisplay
        {
            get
            {
                return PointsAwarded == 1 ? "1pt" : string.Format("{0}pts", PointsAwarded);
            }
        }

        public ThisWeekPageViewModel(IThisWeekService thisWeekService, IDialogService dialogService)
        {
            ThisWeekService = thisWeekService;
            DialogService = dialogService;
        }

        public override async void OnShow()
        {
            try
            {
                var result = await ThisWeekService.GetCurrentWeekSummaryAsync();
                PointsAwarded = result.Points;
            }
            catch
            {
                DialogService.Alert("An error occured getting Current week data");
            }
        }
    }
}
