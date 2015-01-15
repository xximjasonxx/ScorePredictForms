using System;
using ScorePredict.Common.Injection;
using ScorePredict.Data;
using ScorePredict.Services;
using ScorePredict.Services.Client;

namespace ScorePredict.Core.Pages
{
    public partial class LoginPage
    {
        private readonly IPageHelper _pageHelper;
        private readonly ILoginUserService _loginUserService;
        private readonly ISaveUserSecurityService _saveUserSecurityService;
        private readonly IGetUsernameService _getUsernameService;

        public LoginPage()
        {
            InitializeComponent();

            _loginUserService = Resolver.CurrentResolver.Get<ILoginUserService>();
            _saveUserSecurityService = Resolver.CurrentResolver.Get<ISaveUserSecurityService>();
            _pageHelper = Resolver.CurrentResolver.GetInstance<IPageHelper>();
            _getUsernameService = Resolver.CurrentResolver.Get<IGetUsernameService>();
        }

        private void GoToCreateUser(object sender, EventArgs e)
        {
            Navigation.PushAsync(new CreateUserPage());
        }

        private async void Login(object sender, EventArgs ev)
        {
            var errorMessage = string.Empty;
            try
            {
                var user = await _loginUserService.LoginAsync(txtUsername.Text, txtPassword.Text);
                if (user == null)
                    throw new LoginException("Invalid Username Password combination");

                if (string.IsNullOrEmpty(user.Username))
                {
                    await Navigation.PushAsync(new EnterUsernamePage(user));
                    return; // end execution
                }

                _saveUserSecurityService.SaveUser(user);
                Resolver.CurrentResolver.GetInstance<IClient>().AuthenticateUser(user);

                _pageHelper.ShowMain();
            }
            catch (LoginException lex)
            {
                errorMessage = lex.Message;
            }
            catch
            {
                errorMessage = "Login did not succeed. Please try again";
            }

            if (!string.IsNullOrEmpty(errorMessage))
                await DisplayAlert("Error", errorMessage, "Ok");
        }

        private async void FacebookLogin(object sender, EventArgs ev)
        {
            string errorMessage = string.Empty;

            try
            {
                var result = await _loginUserService.LoginWithFacebookAsync();
                if (result == null)
                {
                    throw new LoginException("Failed to Login in with Facebook");
                }

                string username = await _getUsernameService.GetUsernameAsync(result.UserId);
                if (string.IsNullOrEmpty(username))
                {
                    await Navigation.PushAsync(new EnterUsernamePage(result));
                    return;
                }

                Resolver.CurrentResolver.GetInstance<IClient>().AuthenticateUser(result);
                _saveUserSecurityService.SaveUser(result);
                _pageHelper.ShowMain();
            }
            catch (LoginException lex)
            {
                errorMessage = lex.Message;
            }
            catch
            {
                errorMessage = "Login Failed. Please try again.";
            }

            if (!string.IsNullOrEmpty(errorMessage))
                await DisplayAlert("Error", errorMessage, "Ok");
        }
    }
}
