using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.MobileServices;
using ScorePredict.Services;
using ScorePredict.Services.Client;
using ScorePredict.Data;
using System;
using ScorePredict.Common.Injection;

namespace ScorePredict.Touch.Client
{
    public class AzureMobileServiceClient : IClient
    {
		private readonly IWindowHelper _windowHelper;

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

		public AzureMobileServiceClient(IWindowHelper windowHelper)
		{
			_windowHelper = windowHelper;
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
            var result = await Client.InvokeApiAsync(apiName, HttpMethod.Post, parameters);
            return result.AsDictionary();
        }

		public async Task<IDictionary<string, string>> LoginFacebookAsync()
		{
			try
			{
                var vc = _windowHelper.GetKeyWindow().RootViewController.PresentedViewController;
				var result = await Client.LoginAsync(vc, MobileServiceAuthenticationProvider.Facebook);

				return new Dictionary<string, string>
				{
					{"id", result.UserId },
					{"token", result.MobileServiceAuthenticationToken }
				};
			}
            catch(InvalidOperationException)
            {
                throw new LoginException("Login was cancelled");
            }
		}

        #endregion
    }
}

