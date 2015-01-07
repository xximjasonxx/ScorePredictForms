using System;
using ScorePredict.Common.Injection;
using ScorePredict.Droid.Client;
using ScorePredict.Services;
using ScorePredict.Services.Client;

namespace ScorePredict.Droid
{
    public class DroidInjectionModule : InjectionModule
    {
        public DroidInjectionModule()
        {
            AddDependency<IClient>(new AzureMobileServiceClient());
            AddDependency<ISaveUserSecurityService>(typeof(DroidSaveUserSecurityService));
            AddDependency<IReadUserSecurityService>(typeof(DroidReadUserSecurityService));
            AddDependency<IEncryptionService>(typeof(DroidEncryptionService));
        }
    }
}

