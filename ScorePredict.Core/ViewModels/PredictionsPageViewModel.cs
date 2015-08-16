using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using ScorePredict.Common.Data;
using ScorePredict.Common.Utility;
using ScorePredict.Core.Contracts;
using ScorePredict.Core.MessageBus;
using ScorePredict.Core.MessageBus.Messages;
using ScorePredict.Core.Pages;
using ScorePredict.Core.ViewModels.Abstract;
using ScorePredict.Services;
using ScorePredict.Services.Contracts;
using Xamarin.Forms;

namespace ScorePredict.Core.ViewModels
{
    public class PredictionsPageViewModel : ScorePredictRootPageViewModel
    {
        public IPredictionService PredictionService { get; private set; }
        public IReadUserSecurityService ReadUserSecurityService { get; private set; }

        private IList<Prediction> _predictions;
        public IList<PredictionGroup> PredictionGroups
        {
            get
            {
                if (_predictions == null)
                    return new List<PredictionGroup>();

                return (new List<PredictionGroup>
                {
                    new PredictionGroup("Pregame", _predictions.Where(x => x.InPregame).ToList()),
                    new PredictionGroup("Final", _predictions.Where(x => x.IsConcluded).ToList()),
                    new PredictionGroup("In Progress", _predictions.Where(x => !x.IsConcluded && !x.InPregame).ToList())
                }).Where(pg => pg.Count > 0).ToList();
            }
        }

        public bool NoGames
        {
            get { return PredictionGroups.Count == 0; }
        }

        public ICommand SelectPredictionCommand
        {
            get
            {
                return new Command<Prediction>(
                    x => Navigation.PushModalAsync(new ScorePredictNavigationPage(new PredictionEditPage(x))),
                    x => x.InPregame);
            }
        }

        public ICommand RefreshCommand { get { return new Command(Refresh); } }

        public PredictionsPageViewModel(IPredictionService predictionService, IDialogService dialogService,
            IClearUserSecurityService clearUserSecurityService, IBus messageBus, IReadUserSecurityService readUserSecurityService,
            IKillApplication killApp)
            : base(clearUserSecurityService, dialogService, killApp)
        {
            PredictionService = predictionService;
            ReadUserSecurityService = readUserSecurityService;

            messageBus.ListenFor<RefreshPredictionsMessage>(RefreshPredictionGroups);
        }

        private void RefreshPredictionGroups(RefreshPredictionsMessage message)
        {
            var p = _predictions.FirstOrDefault(p1 => p1.PredictionId == message.PredictionId);
            if (p != null)
            {
                p.AwayPredictedScore = message.AwayTeamScore;
                p.HomePredictedScore = message.HomeTeamScore;

                OnPropertyChanged(nameof(PredictionGroups));
            }
        }

        public override async void OnShow()
        {
            if (IsLoaded) return;

            if (ReadUserSecurityService.ReadUser() != null)
            {
                try
                {
                    ShowLoading("Loading Predictions...");
                    await LoadPredictionsAsync();

                    IsLoaded = true;
                }
                catch (Exception ex)
                {
                    DialogService.Alert("Failed to load Predictions. Please refresh");
                }
                finally
                {
                    HideLoading();
                }
            }
        }

        private async void Refresh()
        {
            try
            {
                ShowLoading("Refreshing...");
                await LoadPredictionsAsync();
            }
            catch (Exception)
            {
                DialogService.Alert("Failed to Refresh Predictions. Please try again");
            }
            finally
            {
                HideLoading();
            }
        }

        private async Task LoadPredictionsAsync()
        {
            _predictions = await PredictionService.GetCurrentWeekPredictions();
            OnPropertyChanged(nameof(PredictionGroups));
            OnPropertyChanged(nameof(NoGames));
        }
    }
}
