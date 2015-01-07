using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.MobileServices;
using ScorePredict.Services;
using ScorePredict.Services.Client;
using Xamarin.Forms;
using MonoTouch.UIKit;
using ScorePredict.Data;
using System;
using ScorePredict.Common.Injection;

namespace ScorePredict.Touch.Client
{
    public class AzureMobileServiceClient : IClient
    {
		private readonly IApplicationHelper _applicationHelper;

		public AzureMobileServiceClient()
		{
			_applicationHelper = Resolver.CurrentResolver.GetInstance<IApplicationHelper>();
		}

        #region IClient implementation

        public async Task<IDictionary<string, string>> PostApiAsync(string apiName, IDictionary<string, string> parameters = null)
        {
            var client = new MobileServiceClient(Constants.ApplicationUrl, Constants.ApplicationKey);
            var result = await client.InvokeApiAsync(apiName, HttpMethod.Post, parameters);
            return result.AsDictionary();
        }

		public async Task<IDictionary<string, string>> LoginFacebookAsync()
		{
			try
			{
				var viewController = _applicationHelper.Application.MainPage.CreateViewController();
				var client = new MobileServiceClient(Constants.ApplicationUrl, Constants.ApplicationKey);
				var result = await client.LoginAsync(viewController, MobileServiceAuthenticationProvider.Facebook);

				return new Dictionary<string, string>
				{
					{"id", result.UserId },
					{"token", result.MobileServiceAuthenticationToken }
				};
			}
			catch (Exception ex)
			{
				throw new LoginException("Login Failed");
			}
		}

        #endregion
    }
}

