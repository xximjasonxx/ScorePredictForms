using System;
using Microsoft.WindowsAzure.MobileServices;
using ScorePredict.Data;
using System.Threading.Tasks;

namespace ScorePredict.Services
{
    public class AzureMobileServiceLoginUserService : ILoginUserService
    {
        #region ILoginUserService implementation

        public async Task<ScorePredict.Data.User> LoginAsync(string username, string password)
        {
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
                throw new LoginException("All fields are required");

            return await GetUserAsync(username, password);
        }

        public async Task<User> GetUserAsync(string username, string password)
        {
            var client = new MobileServiceClient(Constants.ApplicationUrl, Constants.ApplicationKey);
            throw new NotImplementedException();
        }

        public async Task<ScorePredict.Data.User> LoginWithFacebookAsync()
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}

