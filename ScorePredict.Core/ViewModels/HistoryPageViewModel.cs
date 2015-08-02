using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;
using ScorePredict.Core.Contracts;
using ScorePredict.Core.Pages;
using ScorePredict.Core.ViewModels.Abstract;
using ScorePredict.Services;
using ScorePredict.Services.Contracts;
using Xamarin.Forms;
using System.Threading.Tasks;

namespace ScorePredict.Core.ViewModels
{
    public class HistoryPageViewModel : ScorePredictRootPageViewModel
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

        public ICommand SelectPredictionYearCommand { get { return new Command<int>(SelectPredictionYear); } }
        public ICommand RefreshCommand { get { return new Command(Refresh); } }

        private async void SelectPredictionYear(int selectedYear)
        {
            await Navigation.PushModalAsync(new ScorePredictNavigationPage(new HistoryDetailPage(selectedYear)));
        }

        public HistoryPageViewModel(IPredictionService predictionService, IClearUserSecurityService clearUserSecurityService,
            IDialogService dialogService, IKillApplication killApp)
            : base(clearUserSecurityService, dialogService, killApp)
        {
            PredictionService = predictionService;
        }

        public async override void OnShow()
        {
            if (IsLoaded) return;

            try
            {
                ShowLoading("Loading History...");
                await LoadPredictionYearsAsync();
                IsLoaded = true;
            }
            catch
            {
                DialogService.Alert("Error occured getting Prediction History");
            }
            finally
            {
                HideLoading();
            }
        }

        private async void Refresh()
        {
            try
            {
                ShowLoading("Refreshing...");
                await LoadPredictionYearsAsync();
            }
            catch
            {
                DialogService.Alert("Failed to refresh Predictions. Please try again.");
            }
            finally
            {
                HideLoading();
            }
        }

        private async Task LoadPredictionYearsAsync()
        {
            PredictionYears = new ObservableCollection<int>(await PredictionService.GetPredictionYearsAsync());
        }
    }
}
