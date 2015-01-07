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
		private readonly IWindowHelper _windowHelper;

		public AzureMobileServiceClient()
		{
			_windowHelper = Resolver.CurrentResolver.GetInstance<IWindowHelper>();
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
                var vc = _windowHelper.GetKeyWindow().RootViewController.PresentedViewController;
				var client = new MobileServiceClient(Constants.ApplicationUrl, Constants.ApplicationKey);
                var result = await client.LoginAsync(vc, MobileServiceAuthenticationProvider.Facebook);

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

