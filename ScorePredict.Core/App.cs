using ScorePredict.Common.Injection;
using ScorePredict.Core.Pages;
using ScorePredict.Services;
using Xamarin.Forms;

namespace ScorePredict.Core
{
    public class App : Application
    {
        public static Page LoginPage
        {
            get
            {
                return new NavigationPage(new LoginPage())
                {
                    BarBackgroundColor = Color.FromHex("#3C8513"),
                    BarTextColor = Color.FromHex("#FCD23C")
                };
            }
        }

        public static Page HomePage
        {
            get
            {
                return new NavigationPage(new MainPage())
                {
                    BarBackgroundColor = Color.FromHex("#3C8513"),
                    BarTextColor = Color.FromHex("#FCD23C")
                };
            }
        }

        private readonly IReadUserSecurityService _readUserSecurityService;

        public App(params InjectionModule[] modules)
        {
            Resolver.CurrentResolver.Initialize(modules);

            _readUserSecurityService = Resolver.CurrentResolver.Get<IReadUserSecurityService>();
            SetMainPage();
        }

        private void SetMainPage()
        {
            var user = _readUserSecurityService.ReadUser();
            if (user == null)
            {
                MainPage = LoginPage;
                return;
            }

            if (string.IsNullOrEmpty(user.Username))
            {
                MainPage = new NavigationPage(new EnterUsernamePage(user))
                {
                    BarBackgroundColor = Color.FromHex("#3C8513"),
                    BarTextColor = Color.FromHex("#FCD23C")
                };
                return;
            }

            MainPage = HomePage;
        }
    }
}
