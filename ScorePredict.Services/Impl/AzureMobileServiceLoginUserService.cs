using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ScorePredict.Common.Data;
using ScorePredict.Common.Ex;
using ScorePredict.Common.Injection;
using ScorePredict.Services.Contracts;
using ScorePredict.Services.Extensions;

namespace ScorePredict.Services.Impl
{
    public class AzureMobileServiceLoginUserService : ILoginUserService
    {
        private readonly IClient _client;
        private readonly IDialogService _dialogService;

        public AzureMobileServiceLoginUserService()
        {
            _client = Resolver.CurrentResolver.GetInstance<IClient>();
            _dialogService = Resolver.CurrentResolver.Get<IDialogService>();
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
                _dialogService.ShowLoading("Logging you In...");
                var result = (await _client.PostApiAsync("login", parameters)).AsDictionary();
                return new User()
                {
                    AuthToken = result["token"],
                    UserId = result["id"],
                    Username = result["username"]
                };
            }
            catch (ApiExecutionException)
            {
                throw new LoginException("Invalid Username or Password. Please try again");
            }
            finally
            {
                _dialogService.HideLoading();
            }
        }

        public async Task<User> LoginWithFacebookAsync()
        {
            return await _client.LoginFacebookAsync();
        }

        #endregion
    }
}

