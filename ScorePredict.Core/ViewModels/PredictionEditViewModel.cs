using System;
using System.Windows.Input;
using ScorePredict.Common.Data;
using ScorePredict.Common.Models;
using ScorePredict.Services;
using ScorePredict.Services.Contracts;
using Xamarin.Forms;

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

        public IDialogService DialogService { get; private set; }
        public IPredictionService PredictionService { get; private set; }

        public ICommand SaveCommand { get { return new Command(Save); } }

        public PredictionEditViewModel(IDialogService dialogService, IPredictionService predictionService)
        {
            DialogService = dialogService;
            PredictionService = predictionService;
        }

        private async void Save()
        {
            try
            {
                DialogService.ShowLoading("Saving...");
                var result = await PredictionService.SavePredictionAsync(new SavePredictionModel()
                {
                    WeekId = Prediction.WeekId,
                    GameId = Prediction.GameId,
                    AwayPrediction = AwayPredictedScore,
                    HomePrediction = HomePredictedScore

                });

                await Navigation.PopAsync(true);
            }
            catch (Exception ex)
            {
                DialogService.Alert("Failed to save Prediction");
            }
            finally
            {
                DialogService.HideLoading();
            }
        }
    }
}
