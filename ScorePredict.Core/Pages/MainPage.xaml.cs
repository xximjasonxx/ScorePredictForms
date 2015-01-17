using System;
using Acr.XamForms.UserDialogs;
using ScorePredict.Common.Injection;
using ScorePredict.Core.Contracts;
using ScorePredict.Services.Contracts;

namespace ScorePredict.Core.Pages
{
    public partial class MainPage
    {
        private readonly IClearUserSecurityService _clearUserSecurityService;
        private readonly IUserDialogService _userDialogService;
        private readonly IPageHelper _pageHelper;

        public MainPage()
        {
            InitializeComponent();

            _clearUserSecurityService = Resolver.CurrentResolver.Get<IClearUserSecurityService>();
            _userDialogService = Resolver.CurrentResolver.GetInstance<IUserDialogService>();
            _pageHelper = Resolver.CurrentResolver.GetInstance<IPageHelper>();
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
