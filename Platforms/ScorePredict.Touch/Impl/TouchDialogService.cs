using System.Threading.Tasks;
using Acr.XamForms.UserDialogs;
using Acr.XamForms.UserDialogs.iOS;
using ScorePredict.Services.Contracts;

namespace ScorePredict.Touch.Impl
{
    public class TouchDialogService : UserDialogService, IDialogService
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
    }
}