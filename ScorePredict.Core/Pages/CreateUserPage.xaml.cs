using System;
using ScorePredict.Common.Ex;
using ScorePredict.Services;
using ScorePredict.Services.Contracts;

namespace ScorePredict.Core.Pages
{
    public partial class CreateUserPage
    {
        public ICreateUserService CreateUserService { get; set; }
        public ISaveUserSecurityService SaveUserSecurityService { get; set; }
        public IDialogService DialogService { get; set; }

        public CreateUserPage()
        {
            InitializeComponent();
        }

        private async void CreateUser(object sender, EventArgs e)
        {
            try
            {
                var result = await CreateUserService.CreateUserAsync(
                    txtUsername.Text,
                    txtPassword.Text,
                    txtConfirm.Text);
                if (result == null)
                    throw new CreateUserException("An error occured creating your user. Please try again");

                SaveUserSecurityService.SaveUser(result);
                //Resolver.CurrentResolver.GetInstance<IClient>().AuthenticateUser(result);

                await Navigation.PopModalAsync(true);
            }
            catch (CreateUserException ex)
            {
                DialogService.Alert(ex.Message);
            }
            catch
            {
                DialogService.Alert("An unknown error occurred. Please try again");
            }
        }
    }
}
