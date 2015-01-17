using System;
using ScorePredict.Common.Injection;
using ScorePredict.Core.Contracts;
using ScorePredict.Services.Contracts;

namespace ScorePredict.Core.Pages
{
    public partial class MainPage
    {
        private readonly IClearUserSecurityService _clearUserSecurityService;
        private readonly IDialogService _dialogService;
        private readonly IPageHelper _pageHelper;

        public MainPage()
        {
            InitializeComponent();

            _clearUserSecurityService = Resolver.CurrentResolver.Get<IClearUserSecurityService>();
            _dialogService = Resolver.CurrentResolver.Get<IDialogService>();
            _pageHelper = Resolver.CurrentResolver.GetInstance<IPageHelper>();
        }

        private async void Logout(object sender, EventArgs ev)
        {
            var result = await _dialogService.ConfirmLogoutAsync();
            if (result)
            {
                _clearUserSecurityService.ClearUserSecurity();
                _pageHelper.ShowLogin();
            }
        }
    }
}
