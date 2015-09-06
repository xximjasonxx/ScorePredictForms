using System;
using System.Windows.Input;
using ScorePredict.Common.Data;
using ScorePredict.Common.Extensions;
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

                AwayPredictedScore = value.AwayPredictedScore == -1 ? string.Empty : value.AwayPredictedScore.ToString();
                HomePredictedScore = value.HomePredictedScore == -1 ? string.Empty : value.HomePredictedScore.ToString();
            }
        }

        private string _awayScorePrediction;
        public string AwayPredictedScore
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

        private string _homeScorePrediction;
        public string HomePredictedScore
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
                var result = await PredictionService.SavePredictionAsync(new SavePredictionModel()
                {
                    PredictionId = Prediction.PredictionId,
                    WeekId = Prediction.WeekId,
                    GameId = Prediction.GameId,
                    AwayPrediction = AwayPredictedScore.AsInt(0),
                    HomePrediction = HomePredictedScore.AsInt(0)
                });

                if (result != null && Prediction != null)
                {
                    MessageBus.Publish(new RefreshPredictionsMessage(Prediction.PredictionId,
                        AwayPredictedScore.AsInt(0), HomePredictedScore.AsInt(0)));
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
