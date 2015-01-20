using Android.Preferences;
using ScorePredict.Common.Data;
using ScorePredict.Core.Contracts;
using ScorePredict.Droid.Impl;
using ScorePredict.Services.Contracts;
using Xamarin.Forms;

[assembly: Dependency(typeof(DroidReadUserSecurityService))]

namespace ScorePredict.Droid.Impl
{
    public class DroidReadUserSecurityService : IReadUserSecurityService
    {
        public IEncryptionService EncryptionService { get; private set; }

        public DroidReadUserSecurityService(IEncryptionService encryptionService)
        {
            EncryptionService = encryptionService;
        }

        public User ReadUser()
        {
            var prefs = PreferenceManager.GetDefaultSharedPreferences(Forms.Context);
            var token = prefs.GetString(AndroidConstants.SharedPrefsTokenKey, string.Empty);
            var userId = prefs.GetString(AndroidConstants.SharedPrefsUserIdKey, string.Empty);

            if (string.IsNullOrEmpty(token) || string.IsNullOrEmpty(userId))
                return null;

            var username = prefs.GetString(AndroidConstants.SharedPrefsUsernameKey, string.Empty);
            return new User()
            {
                AuthToken = EncryptionService.Decrypt(token),
                UserId = EncryptionService.Decrypt(userId),
                Username = username
            };
        }
    }
}