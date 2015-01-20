using Autofac;
using ScorePredict.Common.Data;
using ScorePredict.Core.Contracts;
using ScorePredict.Core.Extensions;
using ScorePredict.Core.Modules;
using ScorePredict.Services.Contracts;
using Xamarin.Forms;

namespace ScorePredict.Core
{
    public class ScorePredictApplication : Application
    {
        public static INavigation Navigation;

        public ScorePredictApplication(IStartupHelper startupHelper, params Module[] modules)
        {
            var builder = new ContainerBuilder();
            builder.RegisterModules(modules);
            builder.RegisterModule(new ViewModelModule());

            ContainerHolder.Initialize(builder.Build());

            var startPage = GetMainPage(startupHelper, ContainerHolder.Current.Resolve<IReadUserSecurityService>());
            builder.RegisterInstance(startPage.Navigation).As<INavigation>().SingleInstance();
            MainPage = startPage;
            Navigation = startPage.Navigation;
        }

        private Page GetMainPage(IStartupHelper startupHelper, IReadUserSecurityService readUserSecurityService)
        {
            User user = readUserSecurityService.ReadUser();
            if (user == null)
                return startupHelper.GetLoginPage();

            if (string.IsNullOrEmpty(user.Username))
                return startupHelper.GetUsernamePage(user);

            return startupHelper.GetMainPage();
        }
    }
}
