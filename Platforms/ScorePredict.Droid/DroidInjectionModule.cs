using System;
using ScorePredict.Common.Injection;
using ScorePredict.Droid.Client;
using ScorePredict.Services;
using ScorePredict.Services.Client;
using Acr.XamForms.UserDialogs.Droid;
using Acr.XamForms.UserDialogs;

namespace ScorePredict.Droid
{
    public class DroidInjectionModule : InjectionModule
    {
        public DroidInjectionModule()
        {
            var userDialogService = new UserDialogService();
            var progressIndicatorService = new ProgressDialogProgressIndicatorService(userDialogService);

            AddDependency<IClient>(new AzureMobileServiceClient(progressIndicatorService));

            AddDependency<ISaveUserSecurityService>(typeof(DroidSaveUserSecurityService));
            AddDependency<IReadUserSecurityService>(typeof(DroidReadUserSecurityService));
            AddDependency<IClearUserSecurityService>(typeof(DroidClearUserSecurityService));
            AddDependency<IEncryptionService>(typeof(DroidEncryptionService));

            AddDependency<IUserDialogService>(userDialogService);
        }
    }
}

