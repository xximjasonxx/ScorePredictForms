using System.Windows.Input;
using ScorePredict.Core.Contracts;
using ScorePredict.Services.Contracts;
using Xamarin.Forms;
using System.Threading.Tasks;

namespace ScorePredict.Core.ViewModels.Abstract
{
    public class ScorePredictBaseViewModel : ViewModelBase
    {
        public IClearUserSecurityService ClearUserSecurityService { get; private set; }
        public IDialogService DialogService { get; private set; }

        private bool _isBusy;
        public bool IsBusy
        {
            get { return _isBusy; }
            protected set
            {
                if (_isBusy != value)
                {
                    _isBusy = value;
                    OnPropertyChanged();
                }
            }
        }

        private string _loaderMessage;
        public string LoaderMessage
        {
            get { return _loaderMessage; }
            protected set
            {
                if (_loaderMessage != value)
                {
                    _loaderMessage = value;
                    OnPropertyChanged();
                }
            }
        }

        public ICommand LogoutCommand { get { return new Command(Logout); } }

        public bool IsLoaded { get; set; }

        protected ScorePredictBaseViewModel(IClearUserSecurityService clearUserSecurityService, IDialogService dialogService)
        {
            ClearUserSecurityService = clearUserSecurityService;
            DialogService = dialogService;
        }

        private async void Logout()
        {
            if (await DialogService.ConfirmLogoutAsync())
            {
                ClearUserSecurityService.ClearUserSecurity();
                await Navigation.PopModalAsync(true);
            }
        }
    }
}
