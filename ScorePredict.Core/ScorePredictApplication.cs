using Autofac;
using ScorePredict.Common.Data;
using ScorePredict.Core.Contracts;
using ScorePredict.Core.Extensions;
using ScorePredict.Core.Modules;
using ScorePredict.Core.Pages;
using ScorePredict.Services.Contracts;
using Xamarin.Forms;

namespace ScorePredict.Core
{
    public class ScorePredictApplication : Application
    {
        public static INavigation Navigation;

        public ScorePredictApplication(INavigator navigator, params Module[] modules)
        {
            var builder = new ContainerBuilder();
            builder.RegisterModules(modules);
            builder.RegisterModule(new ViewModelModule());
            builder.RegisterInstance(navigator).As<INavigator>().SingleInstance();

            ContainerHolder.Initialize(builder.Build());
            var startPage = GetMainPage(ContainerHolder.Current.Resolve<IReadUserSecurityService>());
            MainPage = startPage;
            Navigation = startPage.Navigation;
        }

        private Page GetMainPage(IReadUserSecurityService readUserSecurityService)
        {
            User user = readUserSecurityService.ReadUser();
            if (user == null)
            {
                var navPage = new NavigationPage(new LoginPage())
                {
                    BarBackgroundColor = Color.FromHex("#3C8513"),
                    BarTextColor = Color.FromHex("#FCD23C")
                };

                return navPage;
            }

            if (string.IsNullOrEmpty(user.Username))
                return new NavigationPage(new EnterUsernamePage(user))
                {
                    BarBackgroundColor = Color.FromHex("#3C8513"),
                    BarTextColor = Color.FromHex("#FCD23C")
                };

            return new NavigationPage(new MainPage())
            {
                BarBackgroundColor = Color.FromHex("#3C8513"),
                BarTextColor = Color.FromHex("#FCD23C")
            };
        }
    }
}
