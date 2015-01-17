using System;
using ScorePredict.Common.Ex;
using ScorePredict.Common.Injection;
using ScorePredict.Services;
using ScorePredict.Services.Contracts;

namespace ScorePredict.Core.Pages
{
    public partial class CreateUserPage
    {
        private readonly ICreateUserService _createUserService;
        private readonly ISaveUserSecurityService _saveUserSecurityService;
        private readonly IDialogService _dialogService;

        public CreateUserPage()
        {
            InitializeComponent();

            _createUserService = Resolver.CurrentResolver.Get<ICreateUserService>();
            _saveUserSecurityService = Resolver.CurrentResolver.Get<ISaveUserSecurityService>();
            _dialogService = Resolver.CurrentResolver.Get<IDialogService>();
        }

        private async void CreateUser(object sender, EventArgs e)
        {
            try
            {
                var result = await _createUserService.CreateUserAsync(
                    txtUsername.Text,
                    txtPassword.Text,
                    txtConfirm.Text);
                if (result == null)
                    throw new CreateUserException("An error occured creating your user. Please try again");

                _saveUserSecurityService.SaveUser(result);
                Resolver.CurrentResolver.GetInstance<IClient>().AuthenticateUser(result);

                await Navigation.PopModalAsync(true);
            }
            catch (CreateUserException ex)
            {
                _dialogService.Alert(ex.Message);
            }
            catch
            {
                _dialogService.Alert("An unknown error occurred. Please try again");
            }
        }
    }
}
