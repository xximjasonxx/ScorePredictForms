using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Acr.XamForms.UserDialogs;
using Microsoft.WindowsAzure.MobileServices;
using ScorePredict.Data;
using ScorePredict.Services;
using ScorePredict.Services.Client;

namespace ScorePredict.Phone.Client
{
    public class AzureMobileServiceClient : IClient
    {
        private MobileServiceClient _client;
        private readonly IUserDialogService _userDialogService;

        private MobileServiceClient Client
        {
            get
            {
                if (_client == null)
                    _client = new MobileServiceClient(Constants.ApplicationUrl, Constants.ApplicationKey);

                return _client;
            }
        }

        public AzureMobileServiceClient(IUserDialogService userDIalogService)
        {
            _userDialogService = userDIalogService;
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
                var result = await Client.LoginAsync(MobileServiceAuthenticationProvider.Facebook);
                return new Dictionary<string, string>
                {
                    {"id", result.UserId},
                    {"token", result.MobileServiceAuthenticationToken}
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
