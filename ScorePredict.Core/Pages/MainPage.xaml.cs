using System;
using System.Linq;
using System.Threading.Tasks;
using Acr.XamForms.UserDialogs;
using ScorePredict.Common.Injection;
using ScorePredict.Services;
using Xamarin.Forms;

namespace ScorePredict.Core.Pages
{
    public partial class MainPage
    {
        private readonly IReadUserSecurityService _readUserSecurityService;
        private readonly IClearUserSecurityService _clearUserSecurityService;
        private readonly IUserDialogService _userDialogService;

        public MainPage()
        {
            InitializeComponent();

            _clearUserSecurityService = Resolver.CurrentResolver.Get<IClearUserSecurityService>();
            _userDialogService = Resolver.CurrentResolver.GetInstance<IUserDialogService>();
            _readUserSecurityService = Resolver.CurrentResolver.Get<IReadUserSecurityService>();
        }

        protected override async void OnAppearing()
        {
            var user = _readUserSecurityService.ReadUser();
            if (user == null)
            {
                await ShowLogin();
                return;     // stop execution
            }
        }

        private async void Logout(object sender, EventArgs ev)
        {
            var config = new ConfirmConfig()
                {
                    Message = "Are you sure you want to logout?",
                    OkText = "Yes",
                    CancelText = "No"
                };

            var result = await _userDialogService.ConfirmAsync(config);
            if (result)
            {
                _clearUserSecurityService.ClearUserSecurity();
                await ShowLogin();
            }
        }

        private async Task ShowLogin()
        {
            await Navigation.PushModalAsync(new NavigationPage(new LoginPage())
                {
                    BarBackgroundColor = Color.FromHex("#3C8513"),
                    BarTextColor = Color.FromHex("#FCD23C")
                }, true);
        }
    }
}
