using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.MobileServices;
using ScorePredict.Data;
using ScorePredict.Services;
using ScorePredict.Services.Client;

namespace ScorePredict.Phone.Client
{
    public class AzureMobileServiceClient : IClient
    {
        private MobileServiceClient _client;

        private MobileServiceClient Client
        {
            get
            {
                if (_client == null)
                    _client = new MobileServiceClient(Constants.ApplicationUrl, Constants.ApplicationKey);

                return _client;
            }
        }

        #region IClient implementation

        public void AutneticateUser(User user)
        {
            Client.CurrentUser = new MobileServiceUser(user.UserId)
            {
                MobileServiceAuthenticationToken = user.AuthToken
            };
        }

        public async Task<IDictionary<string, string>> PostApiAsync(string apiName, IDictionary<string, string> parameters = null)
        {
            var result = await Client.InvokeApiAsync("login", HttpMethod.Post, parameters);
            return result.AsDictionary();
        }

        public async Task<IDictionary<string, string>> LoginFacebookAsync()
        {
            try
            {
                var result = await Client.LoginAsync(MobileServiceAuthenticationProvider.Facebook);

                return new Dictionary<string, string>
                {
                    {"id", result.UserId },
                    {"token", result.MobileServiceAuthenticationToken }
                };
            }
            catch
            {
                throw new LoginException("Login Failed");
            }
        }

        #endregion
    }
}
