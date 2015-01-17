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
            AddDependency<IClient>(new AzureMobileServiceClient());
            AddDependency<IReadUserSecurityService>(typeof(PhoneReadUserSecurityService));
            AddDependency<ISaveUserSecurityService>(typeof(PhoneSaveUserSecurityService));
            AddDependency<IClearUserSecurityService>(typeof(PhoneClearUserSecurityService));
            AddDependency<IEncryptionService>(typeof(PhoneEncryptionService));
            AddDependency<IPageHelper>(pageHelper);
            AddDependency<IDialogService>(typeof(PhoneDialogService));
        }
    }
}
