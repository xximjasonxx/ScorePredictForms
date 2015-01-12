using ScorePredict.Common.Injection;

namespace ScorePredict.Core
{
    public class CoreInjectionModule : InjectionModule
    {
        public CoreInjectionModule(IPageHelper pageHelper)
        {
            AddDependency<IPageHelper>(pageHelper);
        }
    }
}
