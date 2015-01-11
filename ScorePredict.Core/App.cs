using ScorePredict.Common.Injection;
using ScorePredict.Core.Pages;
using ScorePredict.Services;
using Xamarin.Forms;

namespace ScorePredict.Core
{
    public class App : Application
    {
        private readonly IReadUserSecurityService _readUserSecurityService;

        public App(params InjectionModule[] modules)
        {
            Resolver.CurrentResolver.Initialize(modules);

            _readUserSecurityService = Resolver.CurrentResolver.Get<IReadUserSecurityService>();
        }

        protected override void OnStart()
        {
            base.OnStart();

            // check if the user is already logged in
            var user = _readUserSecurityService.ReadUser();
            if (user == null)
            {
                MainPage = new NavigationPage(new LoginPage())
                {
                    BarBackgroundColor = Color.FromHex("#3C8513"),
                    BarTextColor = Color.FromHex("#FCD23C")
                };

                return;     // stop execution here
            }

            // check if the user has a username
            if (string.IsNullOrEmpty(user.Username))
            {
                MainPage = new EnterUsernamePage();
                return;
            }

            // all checks passed
            MainPage = new NavigationPage(new MainPage())
            {
                BarBackgroundColor = Color.FromHex("#3C8513"),
                BarTextColor = Color.FromHex("#FCD23C")
            };
        }
    }
}
