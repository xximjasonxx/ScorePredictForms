using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Acr.XamForms.UserDialogs;
using Microsoft.WindowsAzure.MobileServices;
using ScorePredict.Data;
using ScorePredict.Droid.Client;
using ScorePredict.Services;
using ScorePredict.Services.Client;
using Xamarin.Forms;

namespace ScorePredict.Droid.Client
{
    public class AzureMobileServiceClient : IClient
    {
        private readonly IUserDialogService _userDialogService;

        public AzureMobileServiceClient(IUserDialogService userDialogService)
        {
            _userDialogService = userDialogService;
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
                _userDialogService.ShowLoading();

                var result = await Client.InvokeApiAsync(apiName, HttpMethod.Post, parameters);
                return result.AsDictionary();
            }
            finally
            {
                _userDialogService.HideLoading();
            }
        }

        public async Task<IDictionary<string, string>> LoginFacebookAsync()
        {
            try
            {
                _userDialogService.ShowLoading();
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

