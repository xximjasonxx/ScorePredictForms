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
            IDialogService dialogService)
        {
            ClearUserSecurityService = clearUserSecurityService;
            Navigator = navigator;
            DialogService = dialogService;
        }

        private async void Logout()
        {
            if (await DialogService.ConfirmLogoutAsync())
            {
                ClearUserSecurityService.ClearUserSecurity();
                await Navigator.ShowPageAsRootAsync(Navigation, new LoginPage());
            }
        }

        protected virtual void Refresh()
        {
            
        }
    }
}
