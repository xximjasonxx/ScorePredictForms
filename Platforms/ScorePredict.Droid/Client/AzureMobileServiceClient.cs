using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Acr.XamForms.UserDialogs;
using Microsoft.WindowsAzure.MobileServices;
using ScorePredict.Common.Data;
using ScorePredict.Data;
using ScorePredict.Data.Ex;
using ScorePredict.Services;
using ScorePredict.Services.Contracts;
using ScorePredict.Services.Extensions;
using Xamarin.Forms;

namespace ScorePredict.Droid.Client
{
    public class AzureMobileServiceClient : IClient
    {
        private readonly IUserDialogService _userDialogService;

        public AzureMobileServiceClient(IUserDialogService userDialogService)
        {
            _userDialogService = userDialogService;
        }

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
                _userDialogService.ShowLoading();
                var result = await Client.LoginAsync(Forms.Context, MobileServiceAuthenticationProvider.Facebook);

                return new Dictionary<string, string>
                {
                    {"id", result.UserId },
                    {"token", result.MobileServiceAuthenticationToken }
                };
            }
            catch
            {
                throw new LoginException("Login Failed");
            }
        }

        public async Task<IDictionary<string, string>> GetFromTableByKey(string tableName, string key)
        {
            try
            {
                _userDialogService.ShowLoading();

                var table = Client.GetTable(tableName);
                var result = await table.LookupAsync(key);

                return result.AsDictionary();
            }
            catch (MobileServiceInvalidOperationException)
            {
                return new Dictionary<string, string>() { { "username", string.Empty } };
            }
            catch (Exception ex)
            {
                throw new TableOperationException("Read", ex);
            }
            finally
            {
                _userDialogService.HideLoading();
            }
        }

        public async Task<IDictionary<string, string>> InsertIntoTableByKey(string tableName, IDictionary<string, string> parameters)
        {
            try
            {
                _userDialogService.ShowLoading();

                var table = Client.GetTable(tableName);
                var result = await table.InsertAsync(parameters.AsJObject());

                return result.AsDictionary();
            }
            catch (Exception ex)
            {
                throw new TableOperationException("Insert", ex);
            }
            finally
            {
                _userDialogService.HideLoading();
            }
        }

        #endregion
    }
}

