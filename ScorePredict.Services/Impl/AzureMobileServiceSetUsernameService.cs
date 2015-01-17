using System.Collections.Generic;
using System.Threading.Tasks;
using ScorePredict.Common.Injection;
using ScorePredict.Services.Contracts;

namespace ScorePredict.Services.Impl
{
    public class AzureMobileServiceSetUsernameService : ISetUsernameService
    {
        private readonly IClient _client;

        public AzureMobileServiceSetUsernameService()
        {
            _client = Resolver.CurrentResolver.GetInstance<IClient>();
        }

        public async Task<string> SetUsernameForUserAsync(string userId, string username)
        {
            var result = await _client.InsertIntoTableByKey("usernames",
                new Dictionary<string, string>()
                {
                    { "username", username },
                    { "id", userId }
                });

            return result["username"];
        }
    }
}
