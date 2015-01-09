using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ScorePredict.Common.Injection;
using ScorePredict.Services;
using ScorePredict.Services.Client;
using Xamarin.Forms;
using Acr.XamForms.UserDialogs;

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

            _readUserSecurityService = Resolver.CurrentResolver.Get<IReadUserSecurityService>();
            _clearUserSecurityService = Resolver.CurrentResolver.Get<IClearUserSecurityService>();
            _userDialogService = Resolver.CurrentResolver.GetInstance<IUserDialogService>();
        }

        protected override void OnAppearing()
        {
            var user = _readUserSecurityService.ReadUser();
            if (user == null)
            {
                ShowLogin();
            }
            else
            {
                Resolver.CurrentResolver.GetInstance<IClient>().AuthenticateUser(user);
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
                ShowLogin();
            }
        }

        private void ShowLogin()
        {
            Navigation.PushModalAsync(new NavigationPage(new LoginPage())
                {
                    BarBackgroundColor = Color.FromHex("#3C8513"),
                    BarTextColor = Color.FromHex("#FCD23C")
                }, true);
        }
    }
}
