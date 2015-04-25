using System.Collections.ObjectModel;
using System.Windows.Input;
using ScorePredict.Core.Contracts;
using ScorePredict.Core.Pages;
using ScorePredict.Services;
using ScorePredict.Services.Contracts;
using Xamarin.Forms;

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

        public ICommand SelectPredictionYearCommand { get { return new Command<int>(SelectPredictionYear);} }

        private async void SelectPredictionYear(int selectedYear)
        {
            await Navigation.PushModalAsync(new ScorePredictNavigationPage(new HistoryDetailPage(selectedYear)));
        }

        public HistoryPageViewModel(IPredictionService predictionService, IClearUserSecurityService clearUserSecurityService,
            INavigator navigator, IDialogService dialogService, IKillApplication killApp)
            : base(clearUserSecurityService, navigator, dialogService, killApp)
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
            catch
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
