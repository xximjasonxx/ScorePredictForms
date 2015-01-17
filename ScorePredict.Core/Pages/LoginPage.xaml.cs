using System;
using ScorePredict.Common.Ex;
using ScorePredict.Common.Injection;
using ScorePredict.Core.Contracts;
using ScorePredict.Services;
using ScorePredict.Services.Contracts;

namespace ScorePredict.Core.Pages
{
    public partial class LoginPage
    {
        private readonly IPageHelper _pageHelper;
        private readonly ILoginUserService _loginUserService;
        private readonly ISaveUserSecurityService _saveUserSecurityService;
        private readonly IGetUsernameService _getUsernameService;
        private readonly IDialogService _dialogService;

        public LoginPage()
        {
            InitializeComponent();

            _loginUserService = Resolver.CurrentResolver.Get<ILoginUserService>();
            _saveUserSecurityService = Resolver.CurrentResolver.Get<ISaveUserSecurityService>();
            _pageHelper = Resolver.CurrentResolver.GetInstance<IPageHelper>();
            _getUsernameService = Resolver.CurrentResolver.Get<IGetUsernameService>();
            _dialogService = Resolver.CurrentResolver.Get<IDialogService>();
        }

        private void GoToCreateUser(object sender, EventArgs e)
        {
            Navigation.PushAsync(new CreateUserPage());
        }

        private async void Login(object sender, EventArgs ev)
        {
            try
            {
                var user = await _loginUserService.LoginAsync(txtUsername.Text, txtPassword.Text);
                if (user == null)
                    throw new LoginException("Invalid Username Password combination");

                Resolver.CurrentResolver.GetInstance<IClient>().AuthenticateUser(user);

                if (string.IsNullOrEmpty(user.Username))
                {
                    await Navigation.PushAsync(new EnterUsernamePage(user));
                    return; // end execution
                }

                _saveUserSecurityService.SaveUser(user);
                _pageHelper.ShowMain();
            }
            catch (LoginException lex)
            {
                _dialogService.Alert(lex.Message);
            }
            catch
            {
                _dialogService.Alert("Login did not succeed. Please try again");
            }
        }

        private async void FacebookLogin(object sender, EventArgs ev)
        {
            try
            {
                var result = await _loginUserService.LoginWithFacebookAsync();
                if (result == null)
                    throw new LoginException("Failed to Login in with Facebook");

                Resolver.CurrentResolver.GetInstance<IClient>().AuthenticateUser(result);

                string username = await _getUsernameService.GetUsernameAsync(result.UserId);
                if (string.IsNullOrEmpty(username))
                {
                    await Navigation.PushAsync(new EnterUsernamePage(result));
                    return;
                }

                _saveUserSecurityService.SaveUser(result);
                _pageHelper.ShowMain();
            }
            catch (LoginException lex)
            {
                _dialogService.Alert(lex.Message);
            }
            catch
            {
                _dialogService.Alert("Login Failed. Please try again.");
            }
        }
    }
}
