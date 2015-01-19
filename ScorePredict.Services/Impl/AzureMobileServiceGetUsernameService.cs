using System.Threading.Tasks;
using ScorePredict.Common.Ex;
using ScorePredict.Services.Contracts;
using ScorePredict.Services.Extensions;

namespace ScorePredict.Services.Impl
{
    public class AzureMobileServiceGetUsernameService : IGetUsernameService
    {
        public IClient Client { get; set; }
        public IDialogService DialogService { get; set; }

        public async Task<string> GetUsernameAsync(string userId)
        {
            try
            {
                DialogService.ShowLoading("Getting Username...");
                return (await Client.LookupById("usernames", userId)).AsDictionary()["username"];
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
