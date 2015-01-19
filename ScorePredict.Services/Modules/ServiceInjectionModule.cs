using Autofac;
using ScorePredict.Services.Contracts;
using ScorePredict.Services.Impl;

namespace ScorePredict.Services.Modules
{
    public class ServiceInjectionModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<AzureMobileServiceCreateUserService>().As<ICreateUserService>();
            builder.RegisterType<AzureMobileServiceLoginUserService>().As<ILoginUserService>();
            builder.RegisterType<AzureMobileServiceGetUsernameService>().As<IGetUsernameService>();
            builder.RegisterType<AzureMobileServiceSetUsernameService>().As<ISetUsernameService>();
        }
    }
}
