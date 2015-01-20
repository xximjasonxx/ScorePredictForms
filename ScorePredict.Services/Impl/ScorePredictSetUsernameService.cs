using System.Collections.Generic;
using System.Threading.Tasks;
using ScorePredict.Common.Ex;
using ScorePredict.Services.Contracts;
using ScorePredict.Services.Extensions;

namespace ScorePredict.Services.Impl
{
    public class ScorePredictSetUsernameService : ISetUsernameService
    {
        public IClient Client { get; private set; }
        public IDialogService DialogService { get; private set; }

        public ScorePredictSetUsernameService(IClient client, IDialogService dialogService)
        {
            Client = client;
            DialogService = dialogService;
        }

        public async Task<string> SetUsernameForUserAsync(string userId, string username)
        {
            if (string.IsNullOrEmpty(userId) || string.IsNullOrEmpty(username))
                throw new SaveUsernameException("Username cannot be blank");

            return await SaveUsernameForUserAsync(userId, username);
        }

        private async Task<string> SaveUsernameForUserAsync(string userId, string username)
        {
            try
            {
                DialogService.ShowLoading("Saving...");
                var result = await Client.InsertIntoTable("usernames",
                    new Dictionary<string, string>()
                    {
                        {"username", username},
                        {"id", userId}
                    });

                return result.AsDictionary()["username"];
            }
            catch (DuplicateDataException)
            {
                throw new SaveUsernameException("Duplicate Usernames exist. Please choose another");
            }
            finally
            {
                DialogService.HideLoading();
            }
        }
    }
}
