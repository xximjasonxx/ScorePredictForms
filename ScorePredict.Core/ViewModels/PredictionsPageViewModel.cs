using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using ScorePredict.Common.Data;
using ScorePredict.Common.Utility;
using ScorePredict.Core.Contracts;
using ScorePredict.Core.Pages;
using ScorePredict.Services;
using Xamarin.Forms;

namespace ScorePredict.Core.ViewModels
{
    public class PredictionsPageViewModel : ViewModelBase
    {
        public IPredictionService PredictionService { get; private set; }
        public INavigator Navigator { get; private set; }

        private ObservableCollection<PredictionGroup> _predictionGroups;

        public ObservableCollection<PredictionGroup> PredictionGroups
        {
            get { return _predictionGroups; }
            set
            {
                _predictionGroups = value;
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

        public PredictionsPageViewModel(IPredictionService predictionService, INavigator navigator)
        {
            PredictionService = predictionService;
            Navigator = navigator;
        }

        public override async void OnShow()
        {
            /*var result = await PredictionService.GetCurrentWeekPredictions();
            PredictionGroups = new ObservableCollection<PredictionGroup>(new List<PredictionGroup>
            {
                new PredictionGroup("Pregame", result.Where(x => x.InPregame).ToList()),
                new PredictionGroup("Final", result.Where(x => x.IsConcluded).ToList()),
                new PredictionGroup("In Progress", result.Where(x => !x.IsConcluded && !x.InPregame).ToList())
            });*/
        }
    }
}
