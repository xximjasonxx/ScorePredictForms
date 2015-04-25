using System;
using System.Windows.Input;
using ScorePredict.Common.Data;
using ScorePredict.Common.Ex;
using ScorePredict.Core.Contracts;
using ScorePredict.Core.Pages;
using ScorePredict.Core.ViewModels.Abstract;
using ScorePredict.Services.Contracts;
using Xamarin.Forms;

namespace ScorePredict.Core.ViewModels
{
    public class EnterUsernamePageViewModel : ScorePredictBaseViewModel
    {
        public User User { get; set; }
        public string Username { get; set; }

        public ISaveUserSecurityService SaveUserSecurityService { get; private set; }
        public ISetUsernameService SetUsernameService { get; private set; }
        public IKillApplication KillApplication { get; private set; }

        public ICommand SaveCommand { get { return new Command(Save);}}

        public EnterUsernamePageViewModel(ISaveUserSecurityService saveUserSecurityService,
            ISetUsernameService setUsernameService, IClearUserSecurityService clearUserSecurityService,
            IDialogService dialogService, IKillApplication killApp)
            : base(clearUserSecurityService, dialogService)
        {
            SaveUserSecurityService = saveUserSecurityService;
            SetUsernameService = setUsernameService;
            KillApplication = killApp;
        }

        private async void Save()
        {
            try
            {
                var username = await SetUsernameService.SetUsernameForUserAsync(User.UserId, Username);
                User.Username = username;
                SaveUserSecurityService.SaveUser(User);
                
                // on success - pop to root and show the mainview as a modal
                await Navigation.PushModalAsync(new MainPage());
                await Navigation.PopToRootAsync(false);
            }
            catch (SaveUsernameException ex)
            {
                DialogService.Alert(ex.Message);
            }
            catch (Exception ex)
            {
                DialogService.Alert("An error occurred. Please try again");
            }
        }
    }
}
