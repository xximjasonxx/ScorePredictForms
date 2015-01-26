using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ScorePredict.Common.Data;
using ScorePredict.Common.Ex;
using ScorePredict.Services.Contracts;
using ScorePredict.Services.Extensions;

namespace ScorePredict.Services.Impl
{
    public class ScorePredictCreateUserService : ICreateUserService
    {
        public IClient Client { get; private set; }
        public IDialogService DialogService { get; private set; }

        public ScorePredictCreateUserService(IClient client, IDialogService dialogService)
        {
            Client = client;
            DialogService = dialogService;
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
                DialogService.ShowLoading("Creating User...");
                var result = (await Client.PostApiAsync("create_user", parameters)).AsDictionary();
                var user = new User()
                {
                    AuthToken = result[0]["token"],
                    UserId = result[0]["id"],
                    Username = result[0]["username"]
                };

                Client.AuthenticateUser(user);
                return user;
            }
            catch (DuplicateDataException)
            {
                throw new CreateUserException("Duplicate User exists. Please try a different username");
            }
            finally
            {
                DialogService.HideLoading();
            }
        }
    }
}
