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

        public EnterUsernamePage(User user)
        {
            InitializeComponent();

            _theUser = user;
            _saveUserSecurityService = Resolver.CurrentResolver.Get<ISaveUserSecurityService>();
        }

        private async void SubmitUsername(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtUsername.Text))
            {
                await DisplayAlert("Error", "You must provide a username", "Ok");
                return;
            }

            _theUser.Username = txtUsername.Text;
            _saveUserSecurityService.SaveUser(_theUser);
            Resolver.CurrentResolver.GetInstance<IClient>().AuthenticateUser(_theUser);

            await Navigation.PopModalAsync(true);
        }
    }
}
