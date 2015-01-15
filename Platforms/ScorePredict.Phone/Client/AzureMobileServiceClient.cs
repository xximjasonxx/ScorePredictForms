using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Acr.XamForms.UserDialogs;
using Microsoft.WindowsAzure.MobileServices;
using Newtonsoft.Json.Linq;
using ScorePredict.Data;
using ScorePredict.Data.Ex;
using ScorePredict.Services;
using ScorePredict.Services.Client;
using ScorePredict.Services.Extensions;

namespace ScorePredict.Phone.Client
{
    public class AzureMobileServiceClient : IClient
    {
        private MobileServiceClient _client;
        private readonly IUserDialogService _userDialogService;

        private MobileServiceClient Client
        {
            get
            {
                if (_client == null)
                    _client = new MobileServiceClient(Constants.ApplicationUrl, Constants.ApplicationKey);

                return _client;
            }
        }

        public AzureMobileServiceClient(IUserDialogService userDIalogService)
        {
            _userDialogService = userDIalogService;
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
                var result = await Client.LoginAsync(MobileServiceAuthenticationProvider.Facebook);
                return new Dictionary<string, string>
                {
                    {"id", result.UserId},
                    {"token", result.MobileServiceAuthenticationToken}
                };
            }
            catch
            {
                throw new LoginException("Login Failed");
            }
        }

        public async Task<IDictionary<string, string>> GetFromTableByKey(string tableName, string userId)
        {
            try
            {
                _userDialogService.ShowLoading();

                var table = Client.GetTable(tableName);
                var result = await table.LookupAsync(userId);

                return result.AsDictionary();
            }
            catch (MobileServiceInvalidOperationException)
            {
                return new Dictionary<string, string>() {{"username", string.Empty}};
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
            catch (MobileServiceConflictException msex)
            {
                throw new DuplicateDataException("username", msex);
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
