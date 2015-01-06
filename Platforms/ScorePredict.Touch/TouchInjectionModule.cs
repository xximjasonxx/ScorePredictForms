using System;
using ScorePredict.Common.Injection;
using ScorePredict.Services.Client;

namespace ScorePredict.Touch
{
    public class TouchInjectionModule : InjectionModule
    {
        public TouchInjectionModule()
        {
            AddDependency<IClient>(typeof(AzureMobileServiceClient));
        }
    }
}

