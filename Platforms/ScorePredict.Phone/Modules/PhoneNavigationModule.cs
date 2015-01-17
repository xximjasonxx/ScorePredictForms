using ScorePredict.Common.Injection;
using Xamarin.Forms;

namespace ScorePredict.Phone.Modules
{
    public class PhoneNavigationModule : InjectionModule
    {
        public PhoneNavigationModule(INavigation navigation)
        {
            AddDependency<INavigation>(navigation);
        }
    }
}