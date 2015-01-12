using System;
using ScorePredict.Data;

namespace ScorePredict.Core
{
    public class MainPageWithModalGetMainPage : IStartupPageHelper
    {
        #region IGetMainPage implementation

        public Xamarin.Forms.Page GetLoginPage()
        {
            var mainPage = GetMainPage();
            mainPage.Navigation.PushModalAsync(PageFactory.GetLoginPage(), true);

            return mainPage;
        }

        public Xamarin.Forms.Page GetMainPage()
        {
            return PageFactory.GetHomePage();
        }

        public Xamarin.Forms.Page GetUsernamePage(User user)
        {
            var mainPage = GetMainPage();
            mainPage.Navigation.PushModalAsync(PageFactory.GetUsernamePage(user));

            return mainPage;
        }

        #endregion
    }
}

