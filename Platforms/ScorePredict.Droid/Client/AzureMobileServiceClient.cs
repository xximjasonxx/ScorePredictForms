using System;
using System.Collections.Generic;
using Microsoft.WindowsAzure.MobileServices;
using ScorePredict.Services;
using System.Net.Http;
using ScorePredict.Services.Client;
using System.Threading.Tasks;

namespace ScorePredict.Droid
{
    public class AzureMobileServiceClient : IClient
    {
        #region IClient implementation

        public async Task<IDictionary<string, string>> PostApiAsync(string apiName, IDictionary<string, string> parameters = null)
        {
            var client = new MobileServiceClient(Constants.ApplicationUrl, Constants.ApplicationKey);
            var result = await client.InvokeApiAsync("login", HttpMethod.Post, parameters);
            return result.AsDictionary();
        }

        #endregion
    }
}

