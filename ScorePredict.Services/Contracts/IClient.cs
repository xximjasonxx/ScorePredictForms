using System.Collections.Generic;
using System.Threading.Tasks;
using ScorePredict.Common.Data;

namespace ScorePredict.Services.Contracts
{
    public interface IClient
    {
        void AuthenticateUser(User user);

        Task<IDictionary<string, string>> PostApiAsync(string apiName, IDictionary<string, string> parameters = null);
        Task<IDictionary<string, string>> LoginFacebookAsync();

        Task<IDictionary<string, string>> GetFromTableByKey(string table, string key);

        Task<IDictionary<string, string>> InsertIntoTableByKey(string tableName, IDictionary<string, string> parameters);
    }
}

