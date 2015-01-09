using System;
using ScorePredict.Services;
using Acr.XamForms.UserDialogs;

namespace ScorePredict.Droid
{
    public class ProgressDialogProgressIndicatorService : IProgressIndicatorService
    {
        private readonly IUserDialogService _userDialogService;

        public ProgressDialogProgressIndicatorService(IUserDialogService userDialogService)
        {
            _userDialogService = userDialogService;
        }

        #region IProgressIndicatorService implementation

        public void Show(string message = "")
        {
            _userDialogService.ShowLoading();
        }

        public void Hide()
        {
            _userDialogService.HideLoading();
        }

        #endregion
    }
}

