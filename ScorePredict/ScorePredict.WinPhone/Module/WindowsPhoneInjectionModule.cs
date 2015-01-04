using ScorePredict.Data.Services;
using ScorePredict.Injection;
using ScorePredict.WinPhone.Services;

namespace ScorePredict.WinPhone.Module
{
    public class WindowsPhoneInjectionModule : InjectionModule
    {
        public WindowsPhoneInjectionModule()
        {
            AddDependency<ICreateUserService>(typeof(AzureMobileServiceCreateUserService));
        }
    }
}
