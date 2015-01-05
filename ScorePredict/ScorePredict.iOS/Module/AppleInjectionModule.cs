using System;
using System.Collections.Generic;
using System.Text;
using ScorePredict.Data.Services;
using ScorePredict.iOS.Services;
using ScorePredict.Injection;

namespace ScorePredict.iOS.Module
{
    public class AppleInjectionModule : InjectionModule
    {
        public AppleInjectionModule()
        {
            AddDependency<ICreateUserService>(typeof(AzureMobileServiceCreateUserService));
        }
    }
}
