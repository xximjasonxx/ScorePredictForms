using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using ScorePredict.Common.Utility;
using ScorePredict.Core.ViewModels.Abstract;
using ScorePredict.Services;
using ScorePredict.Services.Contracts;
using Xamarin.Forms;

namespace ScorePredict.Core.ViewModels
{
    public class HistoryDetailViewModel : ScorePredictBaseViewModel
    {
        public IPredictionService PredictionService { get; private set; }

        private bool _showProgress;

        public bool ShowProgress
        {
            get { return _showProgress; }
            private set
            {
                if (value != _showProgress)
                {
                    _showProgress = value;
                    OnPropertyChanged();
                }
            }
        }

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

        public ICommand CloseModalCommand { get { return new Command(CloseModal); } }

        private async void CloseModal()
        {
            await Navigation.PopModalAsync(true);
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
                ShowProgress = true;
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
            finally
            {
                ShowProgress = false;
            }
        }
    }
}
