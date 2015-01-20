using System;
using System.Windows.Input;
using ScorePredict.Common.Ex;
using ScorePredict.Services;
using ScorePredict.Services.Contracts;
using Xamarin.Forms;

namespace ScorePredict.Core.ViewModels
{
    public class CreateUserPageViewModel : ViewModelBase
    {
        public ICreateUserService CreateUserService { get; set; }
        public ISaveUserSecurityService SaveUserSecurityService { get; set; }
        public IDialogService DialogService { get; set; }

        public string Username { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }

        public ICommand CreateUserCommand { get {  return new Command(CreateUser);} }

        private async void CreateUser()
        {
            try
            {
                var result = await CreateUserService.CreateUserAsync(
                    Username,
                    Password,
                    ConfirmPassword);
                if (result == null)
                    throw new CreateUserException("An error occured creating your user. Please try again");

                SaveUserSecurityService.SaveUser(result);
                //Resolver.CurrentResolver.GetInstance<IClient>().AuthenticateUser(result);

                await PopModal();
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
