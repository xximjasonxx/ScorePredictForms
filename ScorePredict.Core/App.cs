using ScorePredict.Common.Injection;
using ScorePredict.Core.Pages;
using ScorePredict.Services;
using Xamarin.Forms;

namespace ScorePredict.Core
{
    public class App : Application
    {
        private readonly IReadUserSecurityService _readUserSecurityService;

        public App(IStartupPageHelper getPageHelper, params InjectionModule[] modules)
        {
            Resolver.CurrentResolver.Initialize(modules);

            _readUserSecurityService = Resolver.CurrentResolver.Get<IReadUserSecurityService>();
            SetMainPage(getPageHelper);

            Resolver.CurrentResolver.AddModule(new CoreInjectionModule(MainPage.Navigation));
        }

        private void SetMainPage(IStartupPageHelper getPageHelper)
        {
            var user = _readUserSecurityService.ReadUser();
            if (user == null)
            {
                MainPage = getPageHelper.GetLoginPage();
                return;
            }

            if (string.IsNullOrEmpty(user.Username))
            {
                MainPage = getPageHelper.GetUsernamePage(user);
                return;
            }

            MainPage = getPageHelper.GetMainPage();
        }
    }
}
