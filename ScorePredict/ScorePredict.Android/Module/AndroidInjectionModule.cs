using ScorePredict.Data.Services;
using ScorePredict.Droid.Services;
using ScorePredict.Injection;

namespace ScorePredict.Droid.Module
{
    public class AndroidInjectionModule : InjectionModule
    {
        public AndroidInjectionModule()
        {
            AddDependency<ICreateUserService>(typeof(AzureMobileServiceCreateUserService));
        }
    }
}