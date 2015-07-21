using System;
using System.Windows.Input;
using ScorePredict.Common.Ex;
using ScorePredict.Core.MessageBus;
using ScorePredict.Core.MessageBus.Messages;
using ScorePredict.Core.Pages;
using ScorePredict.Core.ViewModels.Abstract;
using ScorePredict.Services;
using ScorePredict.Services.Contracts;
using Xamarin.Forms;

namespace ScorePredict.Core.ViewModels
{
    public class LoginPageViewModel : ScorePredictBaseViewModel
    {
        public ILoginUserService LoginUserService { get; private set; }
        public ISaveUserSecurityService SaveUserSecurityService { get; private set; }
        public IGetUsernameService GetUsernameService { get; private set; }
        public IReadUserSecurityService ReadUserSecurityService { get; private set; }
        public IStartupService StartupService { get; private set; }
        public IBus MessageBus { get; private set; }

        public string Username { get; set; }
        public string Password { get; set; }

        public ICommand GoToCreateUserCommand { get { return new Command(GoToCreateUser, IsNotInProgress);}}

        public ICommand LoginCommand { get { return new Command(Login, IsNotInProgress); } }

        public ICommand FacebookLoginCommand { get { return new Command(LoginWithFacebook, IsNotInProgress);} }

        public LoginPageViewModel(ILoginUserService loginUserService, ISaveUserSecurityService saveUserSecurityService,
            IGetUsernameService getUsernameService, IDialogService dialogService, IBus messageBus,
            IClearUserSecurityService clearUserSecurityService, IReadUserSecurityService readUserSecurityService, IStartupService startupService)
            : base(clearUserSecurityService, dialogService)
        {
            LoginUserService = loginUserService;
            SaveUserSecurityService = saveUserSecurityService;
            GetUsernameService = getUsernameService;
            MessageBus = messageBus;
            ReadUserSecurityService = readUserSecurityService;
            StartupService = startupService;
        }

        public override async void OnShow()
        {
            var user = ReadUserSecurityService.ReadUser();
            if (user != null)
            {
                if (string.IsNullOrEmpty(user.Username))
                {
                    await Navigation.PushAsync(new EnterUsernamePage(user));
                    return;
                }

                StartupService.SetUser(user);
                try
                {
                    ShowProgress = true;

                    // need to validate that the token is still valid
                    var loginValid = await LoginUserService.CheckUserTokenAsync();
                    if (false)
                    {
                        await Navigation.PushModalAsync(new ScorePredictNavigationPage(new MainPage()));
                    }
                    else
                    {
                        //ClearUserSecurityService.ClearUserSecurity();
                        DialogService.Alert("You session has expired. Please log in again");
                    }
                }
                finally
                {
                    //ShowProgress = false;
                }
            }
        }

        private async void GoToCreateUser()
        {
            await Navigation.PushAsync(new CreateUserPage());
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
                    await Navigation.PushAsync(new EnterUsernamePage(user));
                    return; // end execution
                }

                SaveUserSecurityService.SaveUser(user);
                MessageBus.Publish<LoginCompleteMessage>();
                await Navigation.PushModalAsync(new ScorePredictNavigationPage(new MainPage()));
            }
            catch (LoginException lex)
            {
                DialogService.Alert(lex.Message);
            }
            catch (Exception ex)
            {
                DialogService.Alert("Login did not succeed. Please try again");
            }
        }

        private bool IsNotInProgress()
        {
            return !ShowProgress;
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

                result.Username = username;
                SaveUserSecurityService.SaveUser(result);
                MessageBus.Publish<LoginCompleteMessage>();
                await Navigation.PushModalAsync(new ScorePredictNavigationPage(new MainPage()));
            }
            catch (LoginException lex)
            {
                DialogService.Alert(lex.Message);
            }
            catch (Exception ex)
            {
                DialogService.Alert("Login Failed. Please try again.");
            }
        }
    }
}
