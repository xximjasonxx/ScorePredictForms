using ScorePredict.Common.Injection;
using ScorePredict.Core.Pages;
using ScorePredict.Services;
using Xamarin.Forms;

namespace ScorePredict.Core
{
    public class App : Application
    {
        public App(params InjectionModule[] modules)
        {
            Resolver.CurrentResolver.Initialize(modules);
        }

        protected override void OnStart()
        {
            base.OnStart();
            
            MainPage = new NavigationPage(new MainPage())
            {
                BarBackgroundColor = Color.FromHex("#3C8513"),
                BarTextColor = Color.FromHex("#FCD23C")
            };
        }
    }
}
