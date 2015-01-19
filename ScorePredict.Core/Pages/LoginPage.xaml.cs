using System;
using ScorePredict.Common.Ex;
using ScorePredict.Core.Contracts;
using ScorePredict.Services;
using ScorePredict.Services.Contracts;

namespace ScorePredict.Core.Pages
{
    public partial class LoginPage
    {
        public ILoginUserService LoginUserService { get; set; }
        public ISaveUserSecurityService SaveUserSecurityService { get; set; }
        public IGetUsernameService GetUsernameService { get; set; }
        public IDialogService DialogService { get; set; }

        public LoginPage()
        {
            InitializeComponent();
        }

        private void GoToCreateUser(object sender, EventArgs e)
        {
            Navigation.PushAsync(new CreateUserPage());
        }

        private async void Login(object sender, EventArgs ev)
        {
            try
            {
                var user = await LoginUserService.LoginAsync(txtUsername.Text, txtPassword.Text);
                if (user == null)
                    throw new LoginException("Invalid Username Password combination");

                //Resolver.CurrentResolver.GetInstance<IClient>().AuthenticateUser(user);

                if (string.IsNullOrEmpty(user.Username))
                {
                    await Navigation.PushAsync(new EnterUsernamePage(user));
                    return; // end execution
                }

                SaveUserSecurityService.SaveUser(user);
                //_pageHelper.ShowMain();
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

        private async void FacebookLogin(object sender, EventArgs ev)
        {
            try
            {
                var result = await LoginUserService.LoginWithFacebookAsync();
                if (result == null)
                    throw new LoginException("Failed to Login in with Facebook");

                //Resolver.CurrentResolver.GetInstance<IClient>().AuthenticateUser(result);

                string username = await GetUsernameService.GetUsernameAsync(result.UserId);
                if (string.IsNullOrEmpty(username))
                {
                    await Navigation.PushAsync(new EnterUsernamePage(result));
                    return;
                }

                SaveUserSecurityService.SaveUser(result);
                //_pageHelper.ShowMain();
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
