using Acr.XamForms.UserDialogs;
using Acr.XamForms.UserDialogs.WindowsPhone;
using ScorePredict.Common.Injection;
using ScorePredict.Core.Contracts;
using ScorePredict.Phone.Client;
using ScorePredict.Phone.Impl;
using ScorePredict.Services.Contracts;

namespace ScorePredict.Phone.Modules
{
    public class PhoneInjectionModule : InjectionModule
    {
        public PhoneInjectionModule(IPageHelper pageHelper)
        {
            var userDialogService = new UserDialogService();

            AddDependency<IClient>(new AzureMobileServiceClient(userDialogService));
            AddDependency<IReadUserSecurityService>(typeof(PhoneReadUserSecurityService));
            AddDependency<ISaveUserSecurityService>(typeof(PhoneSaveUserSecurityService));
            AddDependency<IClearUserSecurityService>(typeof(PhoneClearUserSecurityService));
            AddDependency<IEncryptionService>(typeof(PhoneEncryptionService));
            AddDependency<IPageHelper>(pageHelper);
            AddDependency<IUserDialogService>(userDialogService);
        }
    }
}
