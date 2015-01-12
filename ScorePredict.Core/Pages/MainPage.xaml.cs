using System;
using Acr.XamForms.UserDialogs;
using ScorePredict.Common.Injection;
using ScorePredict.Services;

namespace ScorePredict.Core.Pages
{
    public partial class MainPage
    {
        private readonly IReadUserSecurityService _readUserSecurityService;
        private readonly IClearUserSecurityService _clearUserSecurityService;
        private readonly IUserDialogService _userDialogService;
        private readonly IPageHelper _pageHelper;

        public MainPage()
        {
            InitializeComponent();

            _clearUserSecurityService = Resolver.CurrentResolver.Get<IClearUserSecurityService>();
            _userDialogService = Resolver.CurrentResolver.GetInstance<IUserDialogService>();
            _readUserSecurityService = Resolver.CurrentResolver.Get<IReadUserSecurityService>();
            _pageHelper = Resolver.CurrentResolver.GetInstance<IPageHelper>();
        }

        protected override void OnAppearing()
        {
            var user = _readUserSecurityService.ReadUser();
            if (user == null)
            {
                _pageHelper.ShowLogin();
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
                _pageHelper.ShowLogin();
            }
        }
    }
}
