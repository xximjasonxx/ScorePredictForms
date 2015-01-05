using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.MobileServices;
using ScorePredict.Data;
using ScorePredict.Data.Ex;

namespace ScorePredict.Services.Impl
{
    public class AzureMobileServiceCreateUserService : ICreateUserService
    {
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
            try
            {
                MobileServiceClient client = new MobileServiceClient(Constants.ApplicationUrl, Constants.ApplicationKey);
                var parameters = new Dictionary<string, string>
                {
                    {"username", username},
                    {"password", password}
                };

                var result = await client.InvokeApiAsync("create_user", HttpMethod.Post, parameters);
                return new User()
                {
                    AuthToken = result["token"].ToString(),
                    UserId = result["id"].ToString()
                };
            }
            catch (MobileServiceInvalidOperationException msInvalidOpEx)
            {
                throw new CreateUserException(msInvalidOpEx.Message);
            }
        }
    }
}
