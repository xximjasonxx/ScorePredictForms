using System;
using ScorePredict.Common.Injection;
using ScorePredict.Data.Ex;
using ScorePredict.Services;

namespace ScorePredict.Core.Pages
{
    public partial class CreateUserPage
    {
        private readonly ICreateUserService _createUserService;

        public CreateUserPage()
        {
            InitializeComponent();

            _createUserService = Resolver.CurrentResolver.Get<ICreateUserService>();
        }

        private async void CreateUser(object sender, EventArgs e)
        {
            var resultMessage = string.Empty;

            try
            {
                var result = await _createUserService.CreateUserAsync(
                    txtUsername.Text,
                    txtPassword.Text,
                    txtConfirm.Text);
                if (result == null)
                    throw new CreateUserException("An error occured creating your user. Please try again");
            }
            catch (CreateUserException ex)
            {
                resultMessage = ex.Message;
            }
            catch
            {
                resultMessage = "An unknown error occurred. Please try again";
            }

            if (string.IsNullOrEmpty(resultMessage))
                await Navigation.PopModalAsync(true);
            else
                await DisplayAlert("Error", resultMessage, "Ok");
        }
    }
}
