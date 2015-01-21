using System;
using System.Linq;
using System.Windows.Input;
using ScorePredict.Common.Ex;
using ScorePredict.Core.Contracts;
using ScorePredict.Core.Pages;
using ScorePredict.Services;
using ScorePredict.Services.Contracts;
using Xamarin.Forms;

namespace ScorePredict.Core.ViewModels
{
    public class LoginPageViewModel : ViewModelBase
    {
        public ILoginUserService LoginUserService { get; private set; }
        public ISaveUserSecurityService SaveUserSecurityService { get; private set; }
        public IGetUsernameService GetUsernameService { get; private set; }
        public IDialogService DialogService { get; private set; }
        public INavigator Navigator { get; private set; }

        public string Username { get; set; }
        public string Password { get; set; }

        public ICommand GoToCreateUserCommand { get { return new Command(GoToCreateUser);}}

        public ICommand LoginCommand { get { return new Command(Login); } }

        public ICommand FacebookLoginCommand { get { return new Command(LoginWithFacebook);} }

        public LoginPageViewModel(ILoginUserService loginUserService, ISaveUserSecurityService saveUserSecurityService,
            IGetUsernameService getUsernameService, IDialogService dialogService, INavigator navigator)
        {
            LoginUserService = loginUserService;
            SaveUserSecurityService = saveUserSecurityService;
            GetUsernameService = getUsernameService;
            DialogService = dialogService;
            Navigator = navigator;
        }

        private async void GoToCreateUser()
        {
            await Navigator.ShowPageAsync(Navigation, new CreateUserPage());
        }

        private async void Login()
        {
            try
            {
                var user = await LoginUserService.LoginAsync(Username, Password);
                if (user == null)
                    throw new LoginException("Invalid Username Password combination");

                if (string.IsNullOrEmpty(user.Username))
                {
                    await Navigation.PushAsync(new EnterUsernamePage(user), true);
                    return; // end execution
                }

                SaveUserSecurityService.SaveUser(user);
                await Navigator.ShowPageAsRootAsync(Navigation, new MainPage());
            }
            catch (LoginException lex)
            {
                DialogService.Alert(lex.Message);
            }
            catch
            {
                DialogService.Alert("Login did not succeed. Please try again");
            }
        }

        private async void LoginWithFacebook()
        {
            try
            {
                var result = await LoginUserService.LoginWithFacebookAsync();
                if (result == null)
                    throw new LoginException("Failed to Login in with Facebook");

                string username = await GetUsernameService.GetUsernameAsync(result.UserId);
                if (string.IsNullOrEmpty(username))
                {
                    await Navigation.PushAsync(new EnterUsernamePage(result));
                    return;
                }

                SaveUserSecurityService.SaveUser(result);
                await Navigator.ShowPageAsRootAsync(Navigation, new MainPage());
            }
            catch (LoginException lex)
            {
                DialogService.Alert(lex.Message);
            }
            catch
            {
                DialogService.Alert("Login Failed. Please try again.");
            }
        }
    }
}
