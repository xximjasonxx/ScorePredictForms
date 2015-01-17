using Acr.XamForms.UserDialogs;
using Acr.XamForms.UserDialogs.Droid;
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
            var userDialogService = new UserDialogService();

            AddDependency<IClient>(new AzureMobileServiceClient(userDialogService));

            AddDependency<ISaveUserSecurityService>(typeof(DroidSaveUserSecurityService));
            AddDependency<IReadUserSecurityService>(typeof(DroidReadUserSecurityService));
            AddDependency<IClearUserSecurityService>(typeof(DroidClearUserSecurityService));
            AddDependency<IEncryptionService>(typeof(DroidEncryptionService));

            AddDependency<IUserDialogService>(userDialogService);
            AddDependency<IPageHelper>(pageHelper);
        }
    }
}

