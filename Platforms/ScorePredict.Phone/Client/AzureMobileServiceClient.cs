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
        #region IClient implementation

        public async Task<IDictionary<string, string>> PostApiAsync(string apiName, IDictionary<string, string> parameters = null)
        {
            var client = new MobileServiceClient(Constants.ApplicationUrl, Constants.ApplicationKey);
            var result = await client.InvokeApiAsync("login", HttpMethod.Post, parameters);
            return result.AsDictionary();
        }

        public async Task<IDictionary<string, string>> LoginFacebookAsync()
        {
            try
            {
                var client = new MobileServiceClient(Constants.ApplicationUrl, Constants.ApplicationKey);
                var result = await client.LoginAsync(MobileServiceAuthenticationProvider.Facebook);

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
