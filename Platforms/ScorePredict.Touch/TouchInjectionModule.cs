using Autofac;
using ScorePredict.Services.Contracts;
using ScorePredict.Touch.Client;
using ScorePredict.Touch.Contracts;
using ScorePredict.Touch.Impl;
using UIKit;

namespace ScorePredict.Touch
{
    public class TouchInjectionModule : Module
    {
        private readonly UIApplication _app;

        public TouchInjectionModule(UIApplication app)
        {
            _app = app;
        }

        protected override void Load(ContainerBuilder builder)
        {
            var windowHelper = new TouchWindowHelper(_app);
            builder.RegisterInstance(windowHelper).As<IWindowHelper>();

            builder.RegisterType<AzureMobileServiceClient>().As<IClient>().SingleInstance();
            builder.RegisterType<TouchEncryptionService>().As<IEncryptionService>();
            builder.RegisterType<TouchReadUserSecurityService>().As<IReadUserSecurityService>();
            builder.RegisterType<TouchSaveUserSecurityService>().As<ISaveUserSecurityService>();
            builder.RegisterType<TouchClearUserSecurityService>().As<IClearUserSecurityService>();
            builder.RegisterType<TouchDialogService>().As<IDialogService>();
        }
    }
}

