using ScorePredict.Common.Data;
using ScorePredict.Core.Contracts;

namespace ScorePredict.Core.Impl
{
    public class StandardStartupHelper : IStartupHelper
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

