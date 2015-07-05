﻿using System.Windows.Input;
using ScorePredict.Core.Contracts;
using ScorePredict.Services.Contracts;
using Xamarin.Forms;
using System.Threading.Tasks;

namespace ScorePredict.Core.ViewModels.Abstract
{
    public class ScorePredictBaseViewModel : ViewModelBase
    {
        public IClearUserSecurityService ClearUserSecurityService { get; private set; }
        public IDialogService DialogService { get; private set; }
        

        public ICommand LogoutCommand { get { return new Command(Logout); } }
        public ICommand RefreshCommand { get { return new Command(RefreshData); } }

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

        protected ScorePredictBaseViewModel(IClearUserSecurityService clearUserSecurityService, IDialogService dialogService)
        {
            ClearUserSecurityService = clearUserSecurityService;
            DialogService = dialogService;
        }

        private async void Logout()
        {
            if (await DialogService.ConfirmLogoutAsync())
            {
                ClearUserSecurityService.ClearUserSecurity();
                await Navigation.PopModalAsync(true);
            }
        }

        private async void RefreshData()
        {
            try
            {
                ShowProgress = true;
                await Refresh();
            }
            finally
            {
                ShowProgress = false;
            }
        }

        protected virtual async Task Refresh()
        {
            
        }
    }
}
