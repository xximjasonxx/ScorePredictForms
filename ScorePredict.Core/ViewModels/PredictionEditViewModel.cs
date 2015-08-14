using System;
using System.Windows.Input;
using ScorePredict.Common.Data;
using ScorePredict.Common.Models;
using ScorePredict.Core.MessageBus;
using ScorePredict.Core.MessageBus.Messages;
using ScorePredict.Core.ViewModels.Abstract;
using ScorePredict.Services;
using ScorePredict.Services.Contracts;
using Xamarin.Forms;

namespace ScorePredict.Core.ViewModels
{
    public class PredictionEditViewModel : ScorePredictBaseViewModel
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
        public IPredictionService PredictionService { get; private set; }
        public IBus MessageBus { get; private set; }

        public ICommand SaveCommand { get { return new Command(Save); } }

        public ICommand CloseCommand { get { return new Command(Close); } }

        public PredictionEditViewModel(IDialogService dialogService, IPredictionService predictionService,
            IClearUserSecurityService clearUserSecurityService, IBus messageBus)
            : base(clearUserSecurityService, dialogService)
        {
            PredictionService = predictionService;
            MessageBus = messageBus;
        }

        private async void Save()
        {
            try
            {
                DialogService.ShowLoading("Saving...");
                CustomContext.Current.LastPrediction = Prediction;
                var result = await PredictionService.SavePredictionAsync(new SavePredictionModel()
                {
                    PredictionId = Prediction.PredictionId,
                    WeekId = Prediction.WeekId,
                    GameId = Prediction.GameId,
                    AwayPrediction = AwayPredictedScore,
                    HomePrediction = HomePredictedScore
                });

                if (result != null && Prediction != null)
                {
                    Prediction.AwayPredictedScore = AwayPredictedScore;
                    Prediction.HomePredictedScore = HomePredictedScore;

                    MessageBus.Publish<RefreshPredictionsMessage>();
                    await Navigation.PopModalAsync(true);
                }
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

        private async void Close()
        {
            await Navigation.PopModalAsync(true);
        }

        public override bool BackButtonPressed()
        {
            return false;
        }
    }
}
