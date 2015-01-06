using System;
using System.Net.Http;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ScorePredict.Services.Client
{
    public interface IClient
    {
        Task<IDictionary<string, string>> PostApiAsync(string apiName, IDictionary<string, string> parameters = null);
    }
}

