using System;
using ScorePredict.Data;

namespace ScorePredict.Core
{
    public class StandardStartupPageHelper : IStartupPageHelper
    {
        #region IStartupPageHelper implementation

        public Xamarin.Forms.Page GetMainPage()
        {
            return PageFactory.GetHomePage();
        }

        public Xamarin.Forms.Page GetLoginPage()
        {
            return PageFactory.GetLoginPage();
        }

        public Xamarin.Forms.Page GetUsernamePage(User user)
        {
            return PageFactory.GetUsernamePage(user);
        }

        #endregion
    }
}

