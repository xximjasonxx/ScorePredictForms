using System;
using ScorePredict.Data;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Net.Http;
using ScorePredict.Common.Injection;
using ScorePredict.Services.Client;

namespace ScorePredict.Services
{
    public class AzureMobileServiceLoginUserService : ILoginUserService
    {
        private readonly IClient _client;

        public AzureMobileServiceLoginUserService()
        {
            _client = Resolver.CurrentResolver.Get<IClient>();
        }

        #region ILoginUserService implementation

        public async Task<ScorePredict.Data.User> LoginAsync(string username, string password)
        {
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
                throw new LoginException("All fields are required");

            return await LoginUserAsync(username, password);
        }

        public async Task<User> LoginUserAsync(string username, string password)
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
                UserId = result["id"]
            };
        }

        public async Task<ScorePredict.Data.User> LoginWithFacebookAsync()
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}

