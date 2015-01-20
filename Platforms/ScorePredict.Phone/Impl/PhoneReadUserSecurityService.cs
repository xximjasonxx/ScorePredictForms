using System.IO.IsolatedStorage;
using ScorePredict.Common.Data;
using ScorePredict.Core.Contracts;
using ScorePredict.Services.Contracts;

namespace ScorePredict.Phone.Impl
{
    public class PhoneReadUserSecurityService : IReadUserSecurityService
    {
        public IEncryptionService EncryptionService { get; private set; }

        public PhoneReadUserSecurityService(IEncryptionService encryptionService)
        {
            EncryptionService = encryptionService;
        }

        public User ReadUser()
        {
            IsolatedStorageSettings settings = IsolatedStorageSettings.ApplicationSettings;
            string userIdstring;
            if (!settings.TryGetValue(PhoneConstants.SettingsUserIdKey, out userIdstring))
                return null;

            string tokenString;
            if (!settings.TryGetValue(PhoneConstants.SettingsTokenKey, out tokenString))
                return null;

            string username = string.Empty;
            settings.TryGetValue(PhoneConstants.SettingsUsernameKey, out username);

            return new User()
            {
                AuthToken = EncryptionService.Decrypt(tokenString),
                UserId = EncryptionService.Decrypt(userIdstring),
                Username = username
            };
        }
    }
}
