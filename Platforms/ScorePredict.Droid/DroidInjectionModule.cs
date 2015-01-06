using System;
using ScorePredict.Common.Injection;
using ScorePredict.Services.Client;

namespace ScorePredict.Droid
{
    public class DroidInjectionModule : InjectionModule
    {
        public DroidInjectionModule()
        {
            AddDependency<IClient>(typeof(AzureMobileServiceClient));
        }
    }
}

