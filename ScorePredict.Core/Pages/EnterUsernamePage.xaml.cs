using System;
using ScorePredict.Common.Data;
using ScorePredict.Common.Ex;
using ScorePredict.Common.Injection;
using ScorePredict.Core.Contracts;
using ScorePredict.Services.Contracts;

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
            var errorMessage = string.Empty;

            try
            {
                if (string.IsNullOrEmpty(txtUsername.Text))
                {
                    errorMessage = "You must provide a username";
                }
                else
                {
                    var username = await _setUsernameService.SetUsernameForUserAsync(_theUser.UserId, txtUsername.Text);
                    _theUser.Username = username;
                    _saveUserSecurityService.SaveUser(_theUser);

                    _pageHelper.ShowMain();
                }
            }
            catch (DuplicateDataException)
            {
                errorMessage = "Duplicate Username exists, please select another";
            }
            catch
            {
                errorMessage = "An error occurred. Please try again";
            }

            if (!string.IsNullOrEmpty(errorMessage))
                await DisplayAlert("Error", errorMessage, "Ok");
        }
    }
}
