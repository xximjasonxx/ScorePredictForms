using ScorePredict.Common.Data;
using ScorePredict.Core.Pages;
using Xamarin.Forms;

namespace ScorePredict.Core
{
    public static class PageFactory
    {
        public static Page GetLoginPage()
        {
            return new NavigationPage(new LoginPage())
            {
                BarBackgroundColor = Color.FromHex("#3C8513"),
                BarTextColor = Color.FromHex("#FCD23C")
            };
        }

        public static Page GetHomePage()
        {
            return new NavigationPage(new MainPage())
            {
                BarBackgroundColor = Color.FromHex("#3C8513"),
                BarTextColor = Color.FromHex("#FCD23C")
            };
        }

        public static Page GetUsernamePage(User user)
        {
            return new NavigationPage(new EnterUsernamePage(user))
            {
                BarBackgroundColor = Color.FromHex("#3C8513"),
                BarTextColor = Color.FromHex("#FCD23C")
            };
        }
    }
}

