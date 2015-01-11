using ScorePredict.Common.Injection;
using ScorePredict.Services.Impl;

namespace ScorePredict.Services
{
    public class ServiceInjectionModule : InjectionModule
    {
        public ServiceInjectionModule()
        {
            AddDependency<ICreateUserService>(typeof(AzureMobileServiceCreateUserService));
            AddDependency<ILoginUserService>(typeof(AzureMobileServiceLoginUserService));
            AddDependency<IGetUsernameService>(typeof(AzureMobileServiceGetUsernameService));
        }
    }
}
