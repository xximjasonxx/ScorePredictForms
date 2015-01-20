using System.Windows.Input;
using ScorePredict.Common.Data;
using ScorePredict.Common.Ex;
using ScorePredict.Services.Contracts;
using Xamarin.Forms;

namespace ScorePredict.Core.ViewModels
{
    public class EnterUsernamePageViewModel : ViewModelBase
    {
        public User User { get; set; }
        public string Username { get; set; }

        public ISaveUserSecurityService SaveUserSecurityService { get; set; }
        public ISetUsernameService SetUsernameService { get; set; }
        public IDialogService DialogService { get; set; }

        public ICommand SaveCommand { get { return new Command(Save);}}

        private async void Save()
        {
            try
            {
                var username = await SetUsernameService.SetUsernameForUserAsync(User.UserId, Username);
                User.Username = username;
                SaveUserSecurityService.SaveUser(User);
                //_pageHelper.ShowMain();
            }
            catch (SaveUsernameException ex)
            {
                DialogService.Alert(ex.Message);
            }
            catch
            {
                DialogService.Alert("An error occurred. Please try again");
            }
        }
    }
}
