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
            MainPage = new LoginPage();
            Navigation = MainPage.Navigation;
        }
    }
}
