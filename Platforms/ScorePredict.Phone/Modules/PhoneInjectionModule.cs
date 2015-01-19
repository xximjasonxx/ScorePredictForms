using Autofac;
using ScorePredict.Core.Contracts;
using ScorePredict.Phone.Client;
using ScorePredict.Phone.Impl;
using ScorePredict.Services.Contracts;

namespace ScorePredict.Phone.Modules
{
    public class PhoneInjectionModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<AzureMobileServiceClient>().As<IClient>().SingleInstance();
            builder.RegisterType<PhoneReadUserSecurityService>().As<IReadUserSecurityService>();
            builder.RegisterType<PhoneSaveUserSecurityService>().As<ISaveUserSecurityService>();
            builder.RegisterType<PhoneClearUserSecurityService>().As<IClearUserSecurityService>();
            builder.RegisterType<PhoneEncryptionService>().As<IEncryptionService>();
            builder.RegisterType<PhoneDialogService>().As<IDialogService>();
        }
    }
}
