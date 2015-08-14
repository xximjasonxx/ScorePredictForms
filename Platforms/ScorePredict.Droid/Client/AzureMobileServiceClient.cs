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
using Xamarin.Forms;

namespace ScorePredict.Droid.Client
{
    public class AzureMobileServiceClient : MobileServiceClient, IClient
    {
        public AzureMobileServiceClient() : base(Constants.ApplicationUrl, Constants.ApplicationKey)
        {
            
        }

        #region IClient implementation

        public void AuthenticateUser(User user)
        {
            CurrentUser = new MobileServiceUser(user.UserId.ToString())
            {
                MobileServiceAuthenticationToken = user.AuthToken
            };
        }

        public async Task<JToken> GetApiAsync(string apiName, IDictionary<string, string> parameters)
        {
            try
            {
                return await InvokeApiAsync(apiName, HttpMethod.Get, parameters);
            }
            catch (MobileServiceInvalidOperationException ex)
            {
                if (ex.Response.StatusCode == HttpStatusCode.NotFound)
                    throw new NotFoundException(ex.Message);

                if (ex.Response.StatusCode == HttpStatusCode.Unauthorized)
                    throw new InvalidSessionException();

                throw ex;
            }
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

                if (ex.Response.StatusCode == HttpStatusCode.Unauthorized)
                    throw new ApiExecutionException(apiName, ex);

                throw ex;
            }
        }

        public async Task<User> LoginFacebookAsync()
        {
            try
            {
                var result = await this.LoginAsync(Forms.Context, MobileServiceAuthenticationProvider.Facebook);
                return new User
                {
                    UserId = result.UserId,
                    AuthToken = result.MobileServiceAuthenticationToken
                };
            }
            catch (InvalidOperationException)
            {
                throw new LoginException("Login Cancelled");
            }
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

        public async Task<JToken> UpdateTable(string tableName, IDictionary<string, string> parameters)
        {
            try
            {
                var table = GetTable(tableName);
                return await table.UpdateAsync(parameters.AsJObject());
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<JToken> ReadTableAsync(string tableName, IDictionary<string, string> parameters)
        {
            var table = GetTable(tableName);
            return await table.ReadAsync(string.Empty, parameters);
        }

        #endregion
    }
}

