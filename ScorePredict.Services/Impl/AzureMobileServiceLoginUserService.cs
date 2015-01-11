using System.Collections.Generic;
using System.Threading.Tasks;
using ScorePredict.Common.Injection;
using ScorePredict.Data;
using ScorePredict.Services.Client;

namespace ScorePredict.Services.Impl
{
    public class AzureMobileServiceLoginUserService : ILoginUserService
    {
        private readonly IClient _client;
        private readonly IGetUsernameService _getUsernameService;

        public AzureMobileServiceLoginUserService()
        {
            _client = Resolver.CurrentResolver.GetInstance<IClient>();
            _getUsernameService = Resolver.CurrentResolver.Get<IGetUsernameService>();
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

            var result = await _client.PostApiAsync("login", parameters);
            return new User()
            {
                AuthToken = result["token"],
                UserId = result["id"],
                Username = result["username"]
            };
        }

        public async Task<User> LoginWithFacebookAsync()
        {
            var result = await _client.LoginFacebookAsync();
            var username = await _getUsernameService.GetUsernameAsync(result["id"]);

            return new User()
            {
                AuthToken = result["token"],
                UserId = result["id"],
                Username = username
            };
        }

        #endregion
    }
}

