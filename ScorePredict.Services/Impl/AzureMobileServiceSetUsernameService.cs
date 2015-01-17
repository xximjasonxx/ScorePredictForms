using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ScorePredict.Common.Injection;
using ScorePredict.Services.Contracts;
using ScorePredict.Services.Extensions;

namespace ScorePredict.Services.Impl
{
    public class AzureMobileServiceSetUsernameService : ISetUsernameService
    {
        private readonly IClient _client;
        private readonly IDialogService _dialogService;

        public AzureMobileServiceSetUsernameService()
        {
            _client = Resolver.CurrentResolver.GetInstance<IClient>();
            _dialogService = Resolver.CurrentResolver.Get<IDialogService>();
        }

        public async Task<string> SetUsernameForUserAsync(string userId, string username)
        {
            try
            {
                _dialogService.ShowLoading("Saving...");
                var result = await _client.InsertIntoTable("usernames",
                    new Dictionary<string, string>()
                    {
                        {"username", username},
                        {"id", userId}
                    });

                return result.AsDictionary()["username"];
            }
            finally
            {
                _dialogService.HideLoading();
            }
        }
    }
}
