using System.Threading.Tasks;
using ScorePredict.Common.Ex;
using ScorePredict.Services.Contracts;
using ScorePredict.Services.Extensions;

namespace ScorePredict.Services.Impl
{
    public class ScorePredictGetUsernameService : IGetUsernameService
    {
        public IClient Client { get; private set; }
        public IDialogService DialogService { get; private set; }

        public ScorePredictGetUsernameService(IClient client, IDialogService dialogService)
        {
            Client = client;
            DialogService = dialogService;
        }

        public async Task<string> GetUsernameAsync(string userId)
        {
            try
            {
                DialogService.ShowLoading("Getting Username...");
                var dictionary = (await Client.LookupById("usernames", userId)).AsDictionary();

                return dictionary[0]["username"];
            }
            catch (LookupFailedException)
            {
                return string.Empty;
            }
            finally
            {
                DialogService.HideLoading();
            }
        }
    }
}
