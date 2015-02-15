using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ScorePredict.Core.Contracts;
using ScorePredict.Services;
using ScorePredict.Services.Contracts;

namespace ScorePredict.Core.ViewModels
{
    public class HistoryPageViewModel : ScorePredictBaseViewModel
    {
        public IPredictionService PredictionService { get; private set; }

        private ObservableCollection<int> _predictionYears;

        public ObservableCollection<int> PredictionYears
        {
            get { return _predictionYears; }
            private set
            {
                _predictionYears = value;
                OnPropertyChanged();
            }
        }

        public HistoryPageViewModel(IPredictionService predictionService,
            IClearUserSecurityService clearUserSecurityService, INavigator navigator, IDialogService dialogService) :
            base(clearUserSecurityService, navigator, dialogService)
        {
            PredictionService = predictionService;
        }

        public async override void OnShow()
        {
            try
            {
                ShowProgress = true;
                PredictionYears = new ObservableCollection<int>(await PredictionService.GetPredictionYearsAsync());
            }
            catch (Exception ex)
            {
                DialogService.Alert("Error occured getting Prediction History");
            }
            finally
            {
                ShowProgress = false;
            }
        }
    }
}
