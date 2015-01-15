using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.MobileServices;
using ScorePredict.Services;
using ScorePredict.Services.Client;
using ScorePredict.Data;
using System;
using Acr.XamForms.UserDialogs;
using ScorePredict.Common.Injection;
using ScorePredict.Services.Extensions;

namespace ScorePredict.Touch.Client
{
    public class AzureMobileServiceClient : IClient
    {
		private readonly IWindowHelper _windowHelper;
        private readonly IUserDialogService _userDialogService;

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

        public AzureMobileServiceClient(IWindowHelper windowHelper, IUserDialogService userDialogService)
		{
			_windowHelper = windowHelper;
            _userDialogService = userDialogService;
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

        public Task<IDictionary<string, string>> GetFromTableByKey(string table, string key)
        {
            throw new NotImplementedException();
        }

        public Task<IDictionary<string, string>> InsertIntoTableByKey(string tableName, IDictionary<string, string> parameters)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}

