using Autofac;
using ScorePredict.Common.Data;
using ScorePredict.Core.Contracts;
using ScorePredict.Core.Controls;
using ScorePredict.Core.Extensions;
using ScorePredict.Core.Impl;
using ScorePredict.Core.MessageBus;
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
            builder.RegisterInstance(new EmptyKillApplication()).As<IKillApplication>().SingleInstance();
            InitializeApplication(builder, navigator, modules);
        }

        public ScorePredictApplication(INavigator navigator, IKillApplication killApp, params Module[] modules)
        {
            InitializeComponent();

            var builder = new ContainerBuilder();
            builder.RegisterInstance(killApp).As<IKillApplication>().SingleInstance();
            InitializeApplication(builder, navigator, modules);
        }

        private void InitializeApplication(ContainerBuilder builder, INavigator navigator, Module[] modules)
        {
            builder.RegisterInstance(new DefaultMessageBus()).As<IBus>().SingleInstance();
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
            var mainPage = new MainPage();
            
            User user = readUserSecurityService.ReadUser();
            if (user == null)
            {
                mainPage.Navigation.PushModalAsync(new ScorePredictNavigationPage(new LoginPage())
                {
                    BarBackgroundColor = Color.FromHex("#3C8513"),
                    BarTextColor = Color.FromHex("#FCD23C")
                }, false);

                return mainPage;
            }

            startupService.SetUser(user);
            if (string.IsNullOrEmpty(user.Username))
            {
                mainPage.Navigation.PushModalAsync(new ScorePredictNavigationPage(new EnterUsernamePage(user))
                {
                    BarBackgroundColor = Color.FromHex("#3C8513"),
                    BarTextColor = Color.FromHex("#FCD23C")
                }, false);
            }

            return mainPage;
        }
    }
}
