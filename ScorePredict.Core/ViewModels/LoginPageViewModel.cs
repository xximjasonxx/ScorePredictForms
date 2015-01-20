using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using ScorePredict.Common.Ex;
using ScorePredict.Core.Pages;
using ScorePredict.Services;
using ScorePredict.Services.Contracts;
using Xamarin.Forms;

namespace ScorePredict.Core.ViewModels
{
    public class LoginPageViewModel : ViewModelBase
    {
        public ILoginUserService LoginUserService { get; set; }
        public ISaveUserSecurityService SaveUserSecurityService { get; set; }
        public IGetUsernameService GetUsernameService { get; set; }
        public IDialogService DialogService { get; set; }

        public string Username { get; set; }
        public string Password { get; set; }

        public ICommand GoToCreateUserCommand { get { return new Command(GoToCreateUser);}}

        public ICommand LoginCommand { get { return new Command(Login); } }

        public ICommand FacebookLoginCommand { get { return new Command(LoginWithFacebook);} }

        private async void GoToCreateUser()
        {
            await ShowPage(new CreateUserPage());
        }

        private async void Login()
        {
            try
            {
                var user = await LoginUserService.LoginAsync(Username, Password);
                if (user == null)
                    throw new LoginException("Invalid Username Password combination");

                //Resolver.CurrentResolver.GetInstance<IClient>().AuthenticateUser(user);

                if (string.IsNullOrEmpty(user.Username))
                {
                    await ShowPage(new EnterUsernamePage(user));
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

        private async void LoginWithFacebook()
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
                    await ShowPage(new EnterUsernamePage(result));
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
