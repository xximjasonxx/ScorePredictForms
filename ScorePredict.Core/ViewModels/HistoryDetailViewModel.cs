﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using ScorePredict.Common.Utility;
using ScorePredict.Core.ViewModels.Abstract;
using ScorePredict.Services;
using ScorePredict.Services.Contracts;
using Xamarin.Forms;
using System.Threading.Tasks;

namespace ScorePredict.Core.ViewModels
{
    public class HistoryDetailViewModel : ScorePredictBaseViewModel
    {
        public IPredictionService PredictionService { get; private set; }

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

        public HistoryDetailViewModel(IPredictionService predictionService, IDialogService dialogService,
            IClearUserSecurityService clearUserSecurityService)
            : base(clearUserSecurityService, dialogService)
        {
            PredictionService = predictionService;
        }

        public async override void OnShow()
        {
            try
            {
                ShowLoading("Loading History Detail...");
                await LoadPredictionHistoryAsync();
            }
            catch
            {
                DialogService.Alert("Failed to load Predictions for Selected Year");
            }
            finally
            {
                HideLoading();
            }
        }

        protected async Task Refresh()
        {
            try
            {
                ShowLoading("Refreshing...");
                await LoadPredictionHistoryAsync();
            }
            catch
            {
                DialogService.Alert("Failed to reload Predictions. Please try again");
            }
            finally
            {
                HideLoading();
            }
        }

        async Task LoadPredictionHistoryAsync()
        {
            var predictions = await PredictionService.GetPredictionsForYearAsync(Year);
            Predictions = new ObservableCollection<SummaryPredictionGroup>(
                predictions.GroupBy(x => x.WeekNumber)
                .OrderBy(x => x.Key)
                .Select(x => new SummaryPredictionGroup(x.Key.ToString(), x.ToList()))
            );
        }

        public override bool BackButtonPressed()
        {
            return false;
        }
    }
}
