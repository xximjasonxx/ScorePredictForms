using System.Windows.Input;
using ScorePredict.Common.Ex;
using ScorePredict.Core.Contracts;
using ScorePredict.Core.Pages;
using ScorePredict.Services;
using ScorePredict.Services.Contracts;
using Xamarin.Forms;

namespace ScorePredict.Core.ViewModels
{
    public class CreateUserPageViewModel : ViewModelBase
    {
        public ICreateUserService CreateUserService { get; private set; }
        public ISaveUserSecurityService SaveUserSecurityService { get; private set; }
        public IDialogService DialogService { get; private set; }
        public INavigator Navigator { get; private set; }

        public string Username { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }

        public ICommand CreateUserCommand { get {  return new Command(CreateUser);} }

        public CreateUserPageViewModel(ICreateUserService createUserService,
            ISaveUserSecurityService saveUserSecurityService,
            IDialogService dialogService, INavigator navigator)
        {
            CreateUserService = createUserService;
            SaveUserSecurityService = saveUserSecurityService;
            DialogService = dialogService;
            Navigator = navigator;
        }

        private async void CreateUser()
        {
            try
            {
                var result = await CreateUserService.CreateUserAsync(
                    Username,
                    Password,
                    ConfirmPassword);
                if (result == null)
                    throw new CreateUserException("An error occured creating your user. Please try again");

                SaveUserSecurityService.SaveUser(result);
                await Navigator.ShowPageAsRootAsync(Navigation, new MainPage());
            }
            catch (CreateUserException ex)
            {
                DialogService.Alert(ex.Message);
            }
            catch
            {
                DialogService.Alert("An unknown error occurred. Please try again");
            }
        }
    }
}
