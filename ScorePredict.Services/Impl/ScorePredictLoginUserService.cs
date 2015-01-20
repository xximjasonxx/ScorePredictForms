using System.Collections.Generic;
using System.Threading.Tasks;
using ScorePredict.Common.Data;
using ScorePredict.Common.Ex;
using ScorePredict.Services.Contracts;
using ScorePredict.Services.Extensions;

namespace ScorePredict.Services.Impl
{
    public class ScorePredictLoginUserService : ILoginUserService
    {
        public IClient Client { get; private set; }
        public IDialogService DialogService { get; private set; }

        public ScorePredictLoginUserService(IClient client, IDialogService dialogService)
        {
            Client = client;
            DialogService = dialogService;
        }

        #region ILoginUserService implementation

        public async Task<User> LoginAsync(string username, string password)
        {
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
                throw new LoginException("All fields are required");

            return await LoginUserAsync(username, password);
        }

        private async Task<User> LoginUserAsync(string username, string password)
        {
            var parameters = new Dictionary<string, string>
            {
                {"username", username},
                {"password", password}
            };

            try
            {
                DialogService.ShowLoading("Logging you In...");
                var result = (await Client.PostApiAsync("login", parameters)).AsDictionary();
                var user = new User()
                {
                    AuthToken = result["token"],
                    UserId = result["id"],
                    Username = result["username"]
                };

                Client.AuthenticateUser(user);
                return user;
            }
            catch (ApiExecutionException)
            {
                throw new LoginException("Invalid Username or Password. Please try again");
            }
            finally
            {
                DialogService.HideLoading();
            }
        }

        public async Task<User> LoginWithFacebookAsync()
        {
            return await Client.LoginFacebookAsync();
        }

        #endregion
    }
}

