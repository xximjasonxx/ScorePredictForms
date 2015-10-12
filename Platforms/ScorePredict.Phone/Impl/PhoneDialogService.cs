using System.Threading.Tasks;
using Acr.UserDialogs;
using ScorePredict.Services.Contracts;

namespace ScorePredict.Phone.Impl
{
    public class PhoneDialogService : IDialogService
    {
        public void ShowLoading(string message = "Loading")
        {
            UserDialogs.Instance.ShowLoading(message);
        }

        public void HideLoading()
        {
            UserDialogs.Instance.HideLoading();
        }

        public async Task<bool> ConfirmLogoutAsync()
        {
            var config = new ConfirmConfig()
            {
                Message = "Are you sure you want to logout?",
                OkText = "Yes",
                CancelText = "No"
            };

            return await UserDialogs.Instance.ConfirmAsync(config);
        }

        public void Alert(string message)
        {
            var config = new AlertConfig() { Message = message, Title = "Alert", OkText = "Ok" };
            UserDialogs.Instance.Alert(config);
        }
    }
}
