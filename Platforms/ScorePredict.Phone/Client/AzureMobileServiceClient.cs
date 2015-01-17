using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.MobileServices;
using Newtonsoft.Json.Linq;
using ScorePredict.Common.Data;
using ScorePredict.Services;
using ScorePredict.Services.Contracts;
using ScorePredict.Services.Extensions;

namespace ScorePredict.Phone.Client
{
    public class AzureMobileServiceClient : MobileServiceClient, IClient
    {
        public AzureMobileServiceClient()
            : base(Constants.ApplicationUrl, Constants.ApplicationKey)
        {

        }

        #region IClient implementation

        public void AuthenticateUser(User user)
        {
            CurrentUser = new MobileServiceUser(user.UserId)
            {
                MobileServiceAuthenticationToken = user.AuthToken
            };
        }

        public async Task<User> LoginFacebookAsync()
        {
            var result = await this.LoginAsync(MobileServiceAuthenticationProvider.Facebook);
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
