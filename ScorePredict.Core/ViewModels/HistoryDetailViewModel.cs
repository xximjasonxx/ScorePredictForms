using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ScorePredict.Common.Utility;
using ScorePredict.Services;
using ScorePredict.Services.Contracts;

namespace ScorePredict.Core.ViewModels
{
    public class HistoryDetailViewModel : ViewModelBase
    {
        public IPredictionService PredictionService { get; private set; }
        public IDialogService DialogService { get; private set; }

        public int Year { get; set; }

        private ObservableCollection<SummaryPredictionGroup> _predictions;

        public ObservableCollection<SummaryPredictionGroup> Predictions
        {
            get { return _predictions; }
            private set
            {
                _predictions = value;
                OnPropertyChanged();
            }
        }

        public HistoryDetailViewModel(IPredictionService predictionService, IDialogService dialogService)
        {
            PredictionService = predictionService;
            DialogService = dialogService;
        }

        public async override void OnShow()
        {
            try
            {
                var predictions = await PredictionService.GetPredictionsForYearAsync(Year);
                Predictions = new ObservableCollection<SummaryPredictionGroup>(
                    predictions.GroupBy(x => x.WeekNumber)
                        .OrderBy(x => x.Key)
                        .Select(x => new SummaryPredictionGroup(x.Key.ToString(), x.ToList()))
                );
            }
            catch
            {
                DialogService.Alert("Failed to load Predictions for Selected Year");
            }
        }
    }
}
