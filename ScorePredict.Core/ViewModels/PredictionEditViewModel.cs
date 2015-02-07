using ScorePredict.Common.Data;

namespace ScorePredict.Core.ViewModels
{
    public class PredictionEditViewModel : ViewModelBase
    {
        private Prediction _prediction;
        public Prediction Prediction
        {
            get { return _prediction; }
            set
            {
                _prediction = value;
                OnPropertyChanged();

                AwayPredictedScore = value.AwayPredictedScore;
                HomePredictedScore = value.HomePredictedScore;
            }
        }

        private int _awayScorePrediction;
        public int AwayPredictedScore
        {
            get { return _awayScorePrediction; }
            set
            {
                if (_awayScorePrediction != value)
                {
                    _awayScorePrediction = value;
                    OnPropertyChanged();
                }
            }
        }

        private int _homeScorePrediction;
        public int HomePredictedScore
        {
            get { return _homeScorePrediction; }
            set
            {
                if (_homeScorePrediction != value)
                {
                    _homeScorePrediction = value;
                    OnPropertyChanged();
                }
            }
        }
    }
}
