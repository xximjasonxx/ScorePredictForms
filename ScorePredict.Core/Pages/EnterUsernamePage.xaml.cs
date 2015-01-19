using System;
using ScorePredict.Common.Data;
using ScorePredict.Common.Ex;
using ScorePredict.Core.Contracts;
using ScorePredict.Services.Contracts;

namespace ScorePredict.Core.Pages
{
    public partial class EnterUsernamePage
    {
        private readonly User _theUser;
        public ISaveUserSecurityService SaveUserSecurityService { get; set; }
        public ISetUsernameService SetUsernameService { get; set; }
        public IDialogService DialogService { get; set; }

        public EnterUsernamePage(User user)
        {
            InitializeComponent();

            _theUser = user;
        }

        private async void SubmitUsername(object sender, EventArgs e)
        {
            try
            {
                var username = await SetUsernameService.SetUsernameForUserAsync(_theUser.UserId, txtUsername.Text);
                _theUser.Username = username;
                SaveUserSecurityService.SaveUser(_theUser);
                //_pageHelper.ShowMain();
            }
            catch (SaveUsernameException ex)
            {
                DialogService.Alert(ex.Message);
            }
            catch
            {
                DialogService.Alert("An error occurred. Please try again");
            }
        }
    }
}
