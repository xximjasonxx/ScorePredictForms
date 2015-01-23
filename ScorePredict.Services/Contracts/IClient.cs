using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using ScorePredict.Common.Data;

namespace ScorePredict.Services.Contracts
{
    public interface IClient
    {
        void AuthenticateUser(User user);

        Task<JToken> GetApiAsync(string apiName, IDictionary<string, string> parameters);
        Task<JToken> PostApiAsync(string apiName, IDictionary<string, string> parameters);
        Task<User> LoginFacebookAsync();
        Task<JToken> LookupById(string tableName, string key);
        Task<JToken> InsertIntoTable(string tableName, IDictionary<string, string> parameters);
    }
}

