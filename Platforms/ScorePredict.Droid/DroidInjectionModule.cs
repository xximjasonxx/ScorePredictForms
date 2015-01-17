using Acr.XamForms.UserDialogs;
using ScorePredict.Common.Injection;
using ScorePredict.Core.Contracts;
using ScorePredict.Droid.Client;
using ScorePredict.Droid.Impl;
using ScorePredict.Services.Contracts;

namespace ScorePredict.Droid
{
    public class DroidInjectionModule : InjectionModule
    {
        public DroidInjectionModule(IPageHelper pageHelper)
        {
            AddDependency<IClient>(new AzureMobileServiceClient());
            AddDependency<ISaveUserSecurityService>(typeof(DroidSaveUserSecurityService));
            AddDependency<IReadUserSecurityService>(typeof(DroidReadUserSecurityService));
            AddDependency<IClearUserSecurityService>(typeof(DroidClearUserSecurityService));
            AddDependency<IEncryptionService>(typeof(DroidEncryptionService));

            AddDependency<IDialogService>(typeof(DroidDialogService));
            AddDependency<IPageHelper>(pageHelper);
        }
    }
}

