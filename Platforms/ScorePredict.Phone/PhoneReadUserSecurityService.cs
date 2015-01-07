using System.IO.IsolatedStorage;
using ScorePredict.Common.Injection;
using ScorePredict.Data;
using ScorePredict.Services;

namespace ScorePredict.Phone
{
    public class PhoneReadUserSecurityService : IReadUserSecurityService
    {
        private readonly IEncryptionService _encryptionService;

        public PhoneReadUserSecurityService()
        {
            _encryptionService = Resolver.CurrentResolver.Get<IEncryptionService>();
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

            return new User()
            {
                AuthToken = _encryptionService.Decrypt(tokenString),
                UserId = _encryptionService.Decrypt(userIdstring)
            };
        }
    }
}
