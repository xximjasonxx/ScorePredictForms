using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.MobileServices;
using ScorePredict.Data;
using ScorePredict.Services;
using ScorePredict.Services.Client;
using Xamarin.Forms;
using ScorePredict.Common.Injection;

namespace ScorePredict.Droid.Client
{
    public class AzureMobileServiceClient : IClient
    {
        private readonly IProgressIndicatorService _progressIndicatorService;

        public AzureMobileServiceClient(IProgressIndicatorService progressIndicatorService)
        {
            _progressIndicatorService = progressIndicatorService;
        }

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

        public void AuthenticateUser(User user)
        {
            Client.CurrentUser = new MobileServiceUser(user.UserId)
            {
                MobileServiceAuthenticationToken = user.AuthToken
            };
        }

        public async Task<IDictionary<string, string>> PostApiAsync(string apiName, IDictionary<string, string> parameters = null)
        {
            try
            {
                _progressIndicatorService.Show();

                var result = await Client.InvokeApiAsync("login", HttpMethod.Post, parameters);
                return result.AsDictionary();
            }
            finally
            {
                _progressIndicatorService.Hide();
            }
        }

        public async Task<IDictionary<string, string>> LoginFacebookAsync()
        {
            try
            {
                _progressIndicatorService.Show();
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
            finally
            {
                _progressIndicatorService.Hide();
            }
        }

        #endregion
    }
}

