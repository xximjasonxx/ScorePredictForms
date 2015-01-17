using System.Threading.Tasks;
using ScorePredict.Common.Ex;
using ScorePredict.Common.Injection;
using ScorePredict.Services.Contracts;
using ScorePredict.Services.Extensions;

namespace ScorePredict.Services.Impl
{
    public class AzureMobileServiceGetUsernameService : IGetUsernameService
    {
        private readonly IClient _client;
        private readonly IDialogService _dialogService;

        public AzureMobileServiceGetUsernameService()
        {
            _client = Resolver.CurrentResolver.GetInstance<IClient>();
            _dialogService = Resolver.CurrentResolver.Get<IDialogService>();
        }

        public async Task<string> GetUsernameAsync(string userId)
        {
            try
            {
                _dialogService.ShowLoading("Getting Username...");
                return (await _client.LookupById("usernames", userId)).AsDictionary()["username"];
            }
            catch (LookupFailedException)
            {
                return string.Empty;
            }
            finally
            {
                _dialogService.HideLoading();
            }
        }
    }
}
