using ScorePredict.Common.Data;
using ScorePredict.Core.Contracts;

namespace ScorePredict.Core.Impl
{
    public class MainWithModalStartupHelper : IStartupHelper
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

