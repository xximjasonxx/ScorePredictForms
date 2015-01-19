using System;
using ScorePredict.Core.Contracts;
using ScorePredict.Services.Contracts;

namespace ScorePredict.Core.Pages
{
    public partial class MainPage
    {
        public IClearUserSecurityService ClearUserSecurityService { get; set; }
        public IDialogService DialogService { get; set; }

        public MainPage()
        {
            InitializeComponent();
        }

        private async void Logout(object sender, EventArgs ev)
        {
            var result = await DialogService.ConfirmLogoutAsync();
            if (result)
            {
                ClearUserSecurityService.ClearUserSecurity();
                //_pageHelper.ShowLogin();
            }
        }
    }
}
