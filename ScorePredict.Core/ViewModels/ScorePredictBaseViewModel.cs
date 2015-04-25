using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using ScorePredict.Core.Contracts;
using ScorePredict.Core.Pages;
using ScorePredict.Services.Contracts;
using Xamarin.Forms;

namespace ScorePredict.Core.ViewModels
{
    public class ScorePredictBaseViewModel : ViewModelBase
    {
        public IClearUserSecurityService ClearUserSecurityService { get; private set; }
        public INavigator Navigator { get; private set; }
        public IDialogService DialogService { get; private set; }
        public IKillApplication KillApplication { get; private set; }

        public ICommand LogoutCommand { get { return new Command(Logout); } }

        public ICommand RefreshCommand { get { return new Command(Refresh); } }

        private bool _showProgress;

        public bool ShowProgress
        {
            get { return _showProgress; }
            protected set
            {
                if (value != ShowProgress)
                {
                    _showProgress = value;
                    OnPropertyChanged();
                }
            }
        }

        protected ScorePredictBaseViewModel(IClearUserSecurityService clearUserSecurityService, INavigator navigator,
            IDialogService dialogService, IKillApplication killApplication)
        {
            ClearUserSecurityService = clearUserSecurityService;
            Navigator = navigator;
            DialogService = dialogService;
            KillApplication = killApplication;
        }

        private async void Logout()
        {
            if (await DialogService.ConfirmLogoutAsync())
            {
                ClearUserSecurityService.ClearUserSecurity();
                await Navigation.PopModalAsync(true);
            }
        }

        protected virtual void Refresh()
        {
            
        }

        public override bool BackButtonPressed()
        {
            KillApplication.KillApp();
            return true;
        }
    }
}
