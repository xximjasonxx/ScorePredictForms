using Acr.XamForms.UserDialogs;
using Acr.XamForms.UserDialogs.WindowsPhone;
using ScorePredict.Common.Injection;
using ScorePredict.Phone.Client;
using ScorePredict.Services;
using ScorePredict.Services.Client;

namespace ScorePredict.Phone
{
    public class PhoneInjectionModule : InjectionModule
    {
        public PhoneInjectionModule()
        {
            var userDialogService = new UserDialogService();

            AddDependency<IClient>(new AzureMobileServiceClient(userDialogService));
            AddDependency<IReadUserSecurityService>(typeof(PhoneReadUserSecurityService));
            AddDependency<ISaveUserSecurityService>(typeof(PhoneSaveUserSecurityService));
            AddDependency<IClearUserSecurityService>(typeof(PhoneClearUserSecurityService));
            AddDependency<IEncryptionService>(typeof(PhoneEncryptionService));
            AddDependency<IUserDialogService>(userDialogService);
        }
    }
}
