using System;
using ScorePredict.Common.Injection;
using ScorePredict.Data;
using ScorePredict.Services;
using ScorePredict.Services.Client;

namespace ScorePredict.Core.Pages
{
    public partial class EnterUsernamePage
    {
        private readonly User _theUser;
        private readonly ISaveUserSecurityService _saveUserSecurityService;
        private readonly ISetUsernameService _setUsernameService;
        private readonly IPageHelper _pageHelper;

        public EnterUsernamePage(User user)
        {
            InitializeComponent();

            _theUser = user;
            _saveUserSecurityService = Resolver.CurrentResolver.Get<ISaveUserSecurityService>();
            _setUsernameService = Resolver.CurrentResolver.Get<ISetUsernameService>();
            _pageHelper = Resolver.CurrentResolver.GetInstance<IPageHelper>();
        }

        private async void SubmitUsername(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtUsername.Text))
            {
                await DisplayAlert("Error", "You must provide a username", "Ok");
                return;
            }

            var username = await _setUsernameService.SetUsernameForUserAsync(_theUser.UserId, txtUsername.Text);
            _theUser.Username = username;
            _saveUserSecurityService.SaveUser(_theUser);
            Resolver.CurrentResolver.GetInstance<IClient>().AuthenticateUser(_theUser);

            _pageHelper.ShowMain();
        }
    }
}
