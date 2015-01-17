using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ScorePredict.Common.Data;
using ScorePredict.Common.Injection;
using ScorePredict.Data.Ex;
using ScorePredict.Services.Contracts;

namespace ScorePredict.Services.Impl
{
    public class AzureMobileServiceCreateUserService : ICreateUserService
    {
        private readonly IClient _client;
        private readonly IDialogService _dialogService;

        public AzureMobileServiceCreateUserService()
        {
            _client = Resolver.CurrentResolver.GetInstance<IClient>();
            _dialogService = Resolver.CurrentResolver.Get<IDialogService>();
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

            try
            {
                _dialogService.ShowLoading("Creating User...");
                var result = await _client.PostApiAsync("create_user", parameters);
                return new User()
                {
                    AuthToken = result["token"],
                    UserId = result["id"],
                    Username = result["username"]
                };
            }
            finally
            {
                _dialogService.HideLoading();
            }
        }
    }
}
