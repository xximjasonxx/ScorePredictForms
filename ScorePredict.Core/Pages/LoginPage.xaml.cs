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

        public LoginPage()
        {
            InitializeComponent();

            _loginUserService = Resolver.CurrentResolver.Get<ILoginUserService>();
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

                await Navigation.PopModalAsync(true);
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
        }
    }
}
