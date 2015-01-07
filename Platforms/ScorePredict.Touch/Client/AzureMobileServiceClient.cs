using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.MobileServices;
using ScorePredict.Services;
using ScorePredict.Services.Client;

namespace ScorePredict.Touch.Client
{
    public class AzureMobileServiceClient : IClient
    {
        #region IClient implementation

        public async Task<IDictionary<string, string>> PostApiAsync(string apiName, IDictionary<string, string> parameters = null)
        {
            var client = new MobileServiceClient(Constants.ApplicationUrl, Constants.ApplicationKey);
            var result = await client.InvokeApiAsync(apiName, HttpMethod.Post, parameters);
            return result.AsDictionary();
        }

        public Task<IDictionary<string, string>> LoginFacebookAsync()
        {
            throw new System.NotImplementedException();
        }

        #endregion
    }
}

