using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.MobileServices;
using Newtonsoft.Json.Linq;
using ScorePredict.Common.Data;
using ScorePredict.Services;
using ScorePredict.Services.Contracts;
using ScorePredict.Services.Extensions;
using ScorePredict.Touch.Contracts;

namespace ScorePredict.Touch.Client
{
    public class AzureMobileServiceClient : MobileServiceClient, IClient
    {
		private readonly IWindowHelper _windowHelper;

        public AzureMobileServiceClient(IWindowHelper windowHelper)
            : base(Constants.ApplicationUrl, Constants.ApplicationKey)
		{
			_windowHelper = windowHelper;
		}

        #region IClient implementation

        public void AuthenticateUser(User user)
        {
            CurrentUser = new MobileServiceUser(user.UserId)
            {
                MobileServiceAuthenticationToken = user.AuthToken
            };
        }

        public async Task<JToken> PostApiAsync(string apiName, IDictionary<string, string> parameters)
        {
            return await InvokeApiAsync(apiName, HttpMethod.Post, parameters);
        }

        public async Task<User> LoginFacebookAsync()
        {
            var vc = _windowHelper.GetKeyWindow().RootViewController.PresentedViewController;
            var result = await this.LoginAsync(vc, MobileServiceAuthenticationProvider.Facebook);
            return new User
            {
                UserId = result.UserId,
                AuthToken = result.MobileServiceAuthenticationToken
            };
        }

        public async Task<JToken> LookupById(string tableName, string key)
        {
            var table = GetTable(tableName);
            return await table.LookupAsync(key);
        }

        public async Task<JToken> InsertIntoTable(string tableName, IDictionary<string, string> parameters)
        {
            var table = GetTable(tableName);
            return await table.InsertAsync(parameters.AsJObject());
        }

        #endregion
    }
}

