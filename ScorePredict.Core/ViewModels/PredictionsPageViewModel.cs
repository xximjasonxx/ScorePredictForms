using System.Collections.ObjectModel;
using System.Windows.Input;
using ScorePredict.Common.Data;
using ScorePredict.Core.Contracts;
using ScorePredict.Core.Pages;
using ScorePredict.Services;
using Xamarin.Forms;

namespace ScorePredict.Core.ViewModels
{
    public class PredictionsPageViewModel : ViewModelBase
    {
        public IPredictionsService PredictionsService { get; private set; }
        public INavigator Navigator { get; private set; }

        private ObservableCollection<Prediction> _predictions;

        public ObservableCollection<Prediction> Predictions
        {
            get { return _predictions; }
            set
            {
                _predictions = value;
                OnPropertyChanged();
            }
        }

        public ICommand SelectPredictionCommand
        {
            get
            {
                return new Command<Prediction>(
                    x => Navigator.ShowPageAsync(Navigation, new PredictionEditPage(x)),
                    x => x.InPregame);
            }
        }

        public PredictionsPageViewModel(IPredictionsService predictionsService, INavigator navigator)
        {
            PredictionsService = predictionsService;
            Navigator = navigator;
        }

        public override async void OnShow()
        {
            var result = await PredictionsService.GetCurrentWeekPredictions();
            Predictions = new ObservableCollection<Prediction>(result);
        }
    }
}
