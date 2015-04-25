using System.Threading.Tasks;
using Acr.XamForms.UserDialogs;
using Acr.XamForms.UserDialogs.WindowsPhone;
using ScorePredict.Services.Contracts;

namespace ScorePredict.Phone.Impl
{
    public class PhoneDialogService : UserDialogService, IDialogService
    {

        public async Task<bool> ConfirmLogoutAsync()
        {
            var config = new ConfirmConfig()
            {
                Message = "Are you sure you want to logout?",
                OkText = "Yes",
                CancelText = "No"
            };

            return await ConfirmAsync(config);
        }

        public void Alert(string message)
        {
            var config = new AlertConfig() { Message = message, Title = "Alert", OkText = "Ok" };
            Alert(config);
        }
    }
}
