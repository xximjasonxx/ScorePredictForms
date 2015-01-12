using System;
using Xamarin.Forms;
using ScorePredict.Common.Injection;

namespace ScorePredict.Core
{
    public class TouchPageHelper : IPageHelper
    {
        private INavigation Navigation
        {
            get { return Resolver.CurrentResolver.GetInstance<INavigation>(); }
        }

        #region IPageHelper implementation

        public void ShowLogin()
        {
            Navigation.PushModalAsync(PageFactory.GetLoginPage(), true);
        }

        public void ShowMain()
        {
            Navigation.PopModalAsync(true);
        }

        #endregion
    }
}

