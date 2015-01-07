using System.IO.IsolatedStorage;
using ScorePredict.Common.Injection;
using ScorePredict.Data;
using ScorePredict.Services;

namespace ScorePredict.Phone
{
    public class PhoneSaveUserSecurityService : ISaveUserSecurityService
    {
        private readonly IEncryptionService _encryptionService;

        public PhoneSaveUserSecurityService()
        {
            _encryptionService = Resolver.CurrentResolver.Get<IEncryptionService>();
        }

        public void SaveUser(User user)
        {
            IsolatedStorageSettings settings = IsolatedStorageSettings.ApplicationSettings;
            if (!settings.Contains(PhoneConstants.SettingsUserIdKey))
                settings.Add(PhoneConstants.SettingsUserIdKey, string.Empty);
            settings[PhoneConstants.SettingsUserIdKey] = _encryptionService.Encrypt(user.UserId);

            if (!settings.Contains(PhoneConstants.SettingsTokenKey))
                settings.Add(PhoneConstants.SettingsTokenKey, string.Empty);
            settings[PhoneConstants.SettingsTokenKey] = _encryptionService.Encrypt(user.AuthToken);
            settings.Save();
        }
    }
}
