using Autofac;
using ScorePredict.Core.Contracts;
using ScorePredict.Services.Contracts;
using ScorePredict.Touch.Client;
using ScorePredict.Touch.Impl;
using UIKit;

namespace ScorePredict.Touch
{
    public class TouchInjectionModule : Module
    {
        private readonly UIApplication _app;
        private readonly IPageHelper _pageHelper;

        public TouchInjectionModule(UIApplication app)
        {
            _app = app;
        }

        protected override void Load(ContainerBuilder builder)
        {
            var windowHelper = new TouchWindowHelper(_app);
            builder.RegisterInstance(new AzureMobileServiceClient(windowHelper))
                .As<IClient>().SingleInstance();

            builder.RegisterType<IEncryptionService>().As<TouchEncryptionService>();
            builder.RegisterType<TouchReadUserSecurityService>().As<IReadUserSecurityService>();
            builder.RegisterType<TouchSaveUserSecurityService>().As<ISaveUserSecurityService>();
            builder.RegisterType<TouchClearUserSecurityService>().As<IClearUserSecurityService>();
            builder.RegisterType<TouchDialogService>().As<IDialogService>();
        }
    }
}

