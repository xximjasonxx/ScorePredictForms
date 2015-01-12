using ScorePredict.Common.Injection;
using Xamarin.Forms;

namespace ScorePredict.Phone
{
    public class PhoneNavigationModule : InjectionModule
    {
        public PhoneNavigationModule(INavigation navigation)
        {
            AddDependency<INavigation>(navigation);
        }
    }
}