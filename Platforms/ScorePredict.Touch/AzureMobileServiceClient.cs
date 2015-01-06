using System;
using ScorePredict.Services.Client;
using System.Threading.Tasks;
using System.Collections.Generic;
using ScorePredict.Services;
using Microsoft.WindowsAzure.MobileServices;
using System.Net.Http;

namespace ScorePredict.Touch
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

        #endregion
    }
}

