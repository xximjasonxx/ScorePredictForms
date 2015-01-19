using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ScorePredict.Common.Data;
using ScorePredict.Common.Ex;
using ScorePredict.Services.Contracts;
using ScorePredict.Services.Extensions;

namespace ScorePredict.Services.Impl
{
    public class AzureMobileServiceCreateUserService : ICreateUserService
    {
        public IClient Client { get; set; }
        public IDialogService DialogService { get; set; }

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
                return new User()
                {
                    AuthToken = result["token"],
                    UserId = result["id"],
                    Username = result["username"]
                };
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
