using ScorePredict.Common.Injection;
using ScorePredict.Services.Contracts;
using ScorePredict.Services.Impl;

namespace ScorePredict.Services.Modules
{
    public class ServiceInjectionModule : InjectionModule
    {
        public ServiceInjectionModule()
        {
            AddDependency<ICreateUserService>(typeof(AzureMobileServiceCreateUserService));
            AddDependency<ILoginUserService>(typeof(AzureMobileServiceLoginUserService));
            AddDependency<IGetUsernameService>(typeof(AzureMobileServiceGetUsernameService));
            AddDependency<ISetUsernameService>(typeof(AzureMobileServiceSetUsernameService));
        }
    }
}
