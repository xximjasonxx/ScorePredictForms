using ScorePredict.Common.Injection;
using Xamarin.Forms;

namespace ScorePredict.Core
{
    public class CoreInjectionModule : InjectionModule
    {
        public CoreInjectionModule(INavigation navigation)
        {
            AddDependency<INavigation>(navigation);
        }
    }
}
