using System;
using System.Threading.Tasks;
using ScorePredict.Common.Injection;
using ScorePredict.Services.Client;

namespace ScorePredict.Services.Impl
{
    public class AzureMobileServiceGetUsernameService : IGetUsernameService
    {
        private readonly IClient _client;

        public AzureMobileServiceGetUsernameService()
        {
            _client = Resolver.CurrentResolver.GetInstance<IClient>();
        }

        public async Task<string> GetUsernameAsync(string userId)
        {
            return string.Empty;
        }
    }
}
