using Autofac;
using ScorePredict.Common.Data;
using ScorePredict.Core.Contracts;
using ScorePredict.Core.Extensions;
using ScorePredict.Core.Modules;
using ScorePredict.Core.Pages;
using ScorePredict.Services;
using ScorePredict.Services.Contracts;
using Xamarin.Forms;

namespace ScorePredict.Core
{
    public partial class ScorePredictApplication
    {
        public static INavigation Navigation;

        public ScorePredictApplication(INavigator navigator, params Module[] modules)
        {
            InitializeComponent();
            var builder = new ContainerBuilder();
            builder.RegisterModules(modules);
            builder.RegisterModule(new ViewModelModule());
            builder.RegisterInstance(navigator).As<INavigator>().SingleInstance();

            ContainerHolder.Initialize(builder.Build());
            var startPage = GetMainPage(ContainerHolder.Current.Resolve<IReadUserSecurityService>(),
                ContainerHolder.Current.Resolve<IStartupService>());
            MainPage = startPage;
            Navigation = startPage.Navigation;
        }

        private Page GetMainPage(IReadUserSecurityService readUserSecurityService, IStartupService startupService)
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

            startupService.SetUser(user);
            if (string.IsNullOrEmpty(user.Username))
                return new NavigationPage(new EnterUsernamePage(user))
                {
                    BarBackgroundColor = Color.FromHex("#3C8513"),
                    BarTextColor = Color.FromHex("#FCD23C")
                };

            return new MainPage();
            /*)
            {
                BarBackgroundColor = Color.FromHex("#3C8513"),
                BarTextColor = Color.FromHex("#FCD23C")
            };*/
        }
    }
}
