using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using ScorePredict.Data;
using ScorePredict.Data.Ex;
using ScorePredict.Common.Injection;
using ScorePredict.Services.Client;

namespace ScorePredict.Services.Impl
{
    public class AzureMobileServiceCreateUserService : ICreateUserService
    {
        private readonly IClient _client;

        public AzureMobileServiceCreateUserService()
        {
            _client = Resolver.CurrentResolver.Get<IClient>();
        }

        public async Task<User> CreateUserAsync(string username, string password, string confirm)
        {
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
                throw new CreateUserException("All fields are required");

            if (string.Compare(password, confirm, StringComparison.CurrentCultureIgnoreCase) != 0)
                throw new CreateUserException("Passwords do not match");

            return await CreateUserAsync(username, password);
        }

        private async Task<User> CreateUserAsync(string username, string password)
        {
            var parameters = new Dictionary<string, string>
            {
                { "username", username },
                { "password", password }
            };

            var result = await _client.PostApiAsync("create_user", parameters);
            return new User()
            {
                AuthToken = result["token"].ToString(),
                UserId = result["id"].ToString()
            };
        }
    }
}
