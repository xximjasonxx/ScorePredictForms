using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ScorePredict.Common.Data;
using ScorePredict.Services;

namespace ScorePredict.Core.ViewModels
{
    public class PredictionsPageViewModel : ViewModelBase
    {
        public IPredictionsService PredictionsService { get; private set; }

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

        public PredictionsPageViewModel(IPredictionsService predictionsService)
        {
            PredictionsService = predictionsService;
        }

        public override async void OnShow()
        {
            var result = await PredictionsService.GetCurrentWeekPredictions();
        }
    }
}
