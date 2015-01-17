using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.MobileServices;
using ScorePredict.Common.Data;
using ScorePredict.Services;
using ScorePredict.Services.Contracts;
using ScorePredict.Services.Extensions;

namespace ScorePredict.Phone.Client
{
    public class AzureMobileServiceClient : IClient
    {
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
            var result = await Client.InvokeApiAsync(apiName, HttpMethod.Post, parameters);
            return result.AsDictionary();
        }

        public async Task<IDictionary<string, string>> LoginFacebookAsync()
        {
            var result = await Client.LoginAsync(MobileServiceAuthenticationProvider.Facebook);
            return new Dictionary<string, string>
            {
                {"id", result.UserId},
                {"token", result.MobileServiceAuthenticationToken}
            };
        }

        public async Task<IDictionary<string, string>> GetFromTableByKey(string tableName, string userId)
        {
            var table = Client.GetTable(tableName);
            var result = await table.LookupAsync(userId);
            return result.AsDictionary();
        }

        public async Task<IDictionary<string, string>> InsertIntoTableByKey(string tableName, IDictionary<string, string> parameters)
        {
            var table = Client.GetTable(tableName);
            var result = await table.InsertAsync(parameters.AsJObject());
            return result.AsDictionary();
        }

        #endregion
    }
}
