using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.MobileServices;
using Newtonsoft.Json.Linq;
using ScorePredict.Common.Data;
using ScorePredict.Common.Ex;
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

        public async Task<JToken> PostApiAsync(string apiName, IDictionary<string, string> parameters)
        {
            try
            {
                return await InvokeApiAsync(apiName, HttpMethod.Post, parameters);
            }
            catch (MobileServiceInvalidOperationException ex)
            {
                if (ex.Response.StatusCode == HttpStatusCode.Conflict)
                    throw new DuplicateDataException(apiName, ex);

                throw ex;
            }
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
            try
            {
                var table = GetTable(tableName);
                return await table.LookupAsync(key);
            }
            catch (MobileServiceInvalidOperationException ex)
            {
                throw new LookupFailedException(tableName, key, ex);
            }
        }

        public async Task<JToken> InsertIntoTable(string tableName, IDictionary<string, string> parameters)
        {
            try
            {
                var table = GetTable(tableName);
                return await table.InsertAsync(parameters.AsJObject());
            }
            catch (MobileServiceConflictException ex)
            {
                throw new DuplicateDataException(tableName, parameters, ex);
            }
        }

        #endregion
    }
}
