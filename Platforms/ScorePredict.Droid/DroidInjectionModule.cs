using Autofac;
using ScorePredict.Core.Contracts;
using ScorePredict.Droid.Client;
using ScorePredict.Droid.Impl;
using ScorePredict.Services.Contracts;

namespace ScorePredict.Droid
{
    public class DroidInjectionModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<AzureMobileServiceClient>().As<IClient>().SingleInstance();
            builder.RegisterType<DroidSaveUserSecurityService>().As<ISaveUserSecurityService>();
            builder.RegisterType<DroidReadUserSecurityService>().As<IReadUserSecurityService>();
            builder.RegisterType<DroidClearUserSecurityService>().As<IClearUserSecurityService>();
            builder.RegisterType<DroidEncryptionService>().As<IEncryptionService>();
            builder.RegisterType<DroidDialogService>().As<IDialogService>();
        }
    }
}

