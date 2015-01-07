using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.MobileServices;
using ScorePredict.Common.Injection;
using ScorePredict.Data;
using ScorePredict.Services;
using ScorePredict.Services.Client;
using Xamarin.Forms;

namespace ScorePredict.Droid.Client
{
    public class AzureMobileServiceClient : IClient
    {
        private readonly IReadUserSecurityService _readUserSecurityService;

        public AzureMobileServiceClient()
        {
            _readUserSecurityService = Resolver.CurrentResolver.Get<IReadUserSecurityService>();
        }

        private MobileServiceClient Client
        {
            get
            {
                var client = new MobileServiceClient(Constants.ApplicationUrl, Constants.ApplicationKey);
                var currentUser = _readUserSecurityService.ReadUser();

                if (currentUser != null)
                {
                    client.CurrentUser = new MobileServiceUser(currentUser.UserId)
                    {
                        MobileServiceAuthenticationToken = currentUser.AuthToken
                    };
                }

                return client;
            }
        }

        #region IClient implementation

        public async Task<IDictionary<string, string>> PostApiAsync(string apiName, IDictionary<string, string> parameters = null)
        {
            var result = await Client.InvokeApiAsync("login", HttpMethod.Post, parameters);
            return result.AsDictionary();
        }

        public async Task<IDictionary<string, string>> LoginFacebookAsync()
        {
            try
            {
                var result = await Client.LoginAsync(Forms.Context, MobileServiceAuthenticationProvider.Facebook);

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

