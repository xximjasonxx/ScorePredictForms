using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ScorePredict.Services;
using ScorePredict.Common.Injection;
using ScorePredict.Data;

namespace ScorePredict.Core.Pages
{
    public partial class LoginPage
    {
        private readonly ILoginUserService _loginUserService;
        private readonly ISaveUserSecurityService _saveUserSecurityService;

        public LoginPage()
        {
            InitializeComponent();

            _loginUserService = Resolver.CurrentResolver.Get<ILoginUserService>();
            _saveUserSecurityService = Resolver.CurrentResolver.Get<ISaveUserSecurityService>();
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
                {
                    throw new LoginException("Invalid Username Password combination");
                }

                _saveUserSecurityService.SaveUser(user);
                await Navigation.PopModalAsync(true);
            }
            catch (LoginException lex)
            {
                errorMessage = lex.Message;
            }
            catch (Exception ex)
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

                _saveUserSecurityService.SaveUser(result);
                await Navigation.PopModalAsync(true);
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
