using System.Windows.Input;
using ScorePredict.Core.Contracts;
using ScorePredict.Core.Pages;
using ScorePredict.Services.Contracts;
using Xamarin.Forms;

namespace ScorePredict.Core.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
        public IClearUserSecurityService ClearUserSecurityService { get; private set; }
        public IDialogService DialogService { get; private set; }
        public INavigator Navigator { get; private set; }

        public MainPageViewModel(IClearUserSecurityService clearUserSecurityService, IDialogService dialogService,
            INavigator navigator)
        {
            ClearUserSecurityService = clearUserSecurityService;
            DialogService = dialogService;
            Navigator = navigator;
        }

        public ICommand LogoutCommand { get { return new Command(Logout); } }

        public async void Logout()
        {
            if (await DialogService.ConfirmLogoutAsync())
            {
                ClearUserSecurityService.ClearUserSecurity();
                await Navigator.ShowPageAsRootAsync(Navigation, new LoginPage());
            }
        }
    }
}
