using Autofac;
using ScorePredict.Core.Contracts;
using ScorePredict.Core.Extensions;
using ScorePredict.Core.Impl;
using ScorePredict.Core.MessageBus;
using ScorePredict.Core.Modules;
using ScorePredict.Core.Pages;
using Xamarin.Forms;

namespace ScorePredict.Core
{
    public partial class ScorePredictApplication
    {
        public static INavigation Navigation;

        public ScorePredictApplication(params Module[] modules)
        {
            InitializeComponent();

            var builder = new ContainerBuilder();
            builder.RegisterInstance(new EmptyKillApplication()).As<IKillApplication>().SingleInstance();
            InitializeApplication(builder, modules);
        }

        public ScorePredictApplication(IKillApplication killApp, params Module[] modules)
        {
            InitializeComponent();

            var builder = new ContainerBuilder();
            builder.RegisterInstance(killApp).As<IKillApplication>().SingleInstance();
            InitializeApplication(builder, modules);
        }

        private void InitializeApplication(ContainerBuilder builder, Module[] modules)
        {
            builder.RegisterInstance(new DefaultMessageBus()).As<IBus>().SingleInstance();
            builder.RegisterModules(modules);
            builder.RegisterModule(new ViewModelModule());

            ContainerHolder.Initialize(builder.Build());
            MainPage = new NavigationPage(new LoginPage())
            {
				BarBackgroundColor = Color.FromHex("#3C8513"),
				BarTextColor = Color.FromHex("#FCD23C")
            };

            Navigation = MainPage.Navigation;
        }
    }
}
