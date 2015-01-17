using System.Threading.Tasks;
using ScorePredict.Common.Injection;
using ScorePredict.Services.Contracts;

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
                var response = await _client.GetFromTableByKey("usernames", userId);
                return response["username"];
            }
            finally
            {
                _dialogService.HideLoading();
            }
        }
    }
}
