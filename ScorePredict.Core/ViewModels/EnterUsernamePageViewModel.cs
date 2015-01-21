using System.Windows.Input;
using ScorePredict.Common.Data;
using ScorePredict.Common.Ex;
using ScorePredict.Core.Contracts;
using ScorePredict.Core.Pages;
using ScorePredict.Services.Contracts;
using Xamarin.Forms;

namespace ScorePredict.Core.ViewModels
{
    public class EnterUsernamePageViewModel : ViewModelBase
    {
        public User User { get; set; }
        public string Username { get; set; }

        public ISaveUserSecurityService SaveUserSecurityService { get; private set; }
        public ISetUsernameService SetUsernameService { get; private set; }
        public IDialogService DialogService { get; private set; }
        public INavigator Navigator { get; private set; }

        public ICommand SaveCommand { get { return new Command(Save);}}

        public EnterUsernamePageViewModel(ISaveUserSecurityService saveUserSecurityService,
            ISetUsernameService setUsernameService,
            IDialogService dialogService, INavigator navigator)
        {
            SaveUserSecurityService = saveUserSecurityService;
            SetUsernameService = setUsernameService;
            DialogService = dialogService;
            Navigator = navigator;
        }

        private async void Save()
        {
            try
            {
                var username = await SetUsernameService.SetUsernameForUserAsync(User.UserId, Username);
                User.Username = username;
                SaveUserSecurityService.SaveUser(User);
                await Navigator.ShowPageAsRootAsync(Navigation, new MainPage());
            }
            catch (SaveUsernameException ex)
            {
                DialogService.Alert(ex.Message);
            }
            catch
            {
                DialogService.Alert("An error occurred. Please try again");
            }
        }
    }
}
