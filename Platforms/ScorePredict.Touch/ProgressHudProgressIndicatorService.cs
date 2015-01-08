using System;
using ScorePredict.Services;
using MBProgressHUD;

namespace ScorePredict.Touch
{
    public class ProgressHudProgressIndicatorService : IProgressIndicatorService
    {
        private MTMBProgressHUD _progressHud;
        private readonly IWindowHelper _windowHelper;

        public ProgressHudProgressIndicatorService(IWindowHelper helper)
        {
            _windowHelper = helper;
        }

        #region IProgressIndicatorService implementation

        public void Show(string message = "")
        {
            var vc = _windowHelper.GetKeyWindow().RootViewController.PresentedViewController;
            _progressHud = new MTMBProgressHUD (vc.View) {
                LabelText = message,
                RemoveFromSuperViewOnHide = true
            };

            vc.View.AddSubview (_progressHud);
            _progressHud.Show (animated: true);
        }

        public void Hide()
        {
            _progressHud.Hide(true);
        }

        #endregion
    }
}

