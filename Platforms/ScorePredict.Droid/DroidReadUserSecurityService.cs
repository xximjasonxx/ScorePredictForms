using Android.Preferences;
using ScorePredict.Common.Injection;
using ScorePredict.Data;
using ScorePredict.Droid;
using ScorePredict.Services;
using Xamarin.Forms;

[assembly: Dependency(typeof(DroidReadUserSecurityService))]

namespace ScorePredict.Droid
{
    public class DroidReadUserSecurityService : IReadUserSecurityService
    {
        private readonly IEncryptionService _encryptionService;

        public DroidReadUserSecurityService()
        {
            _encryptionService = Resolver.CurrentResolver.Get<IEncryptionService>();
        }

        public User ReadUser()
        {
            var prefs = PreferenceManager.GetDefaultSharedPreferences(Forms.Context);
            var token = prefs.GetString(AndroidConstants.SharedPrefsTokenKey, string.Empty);
            var userId = prefs.GetString(AndroidConstants.SharedPrefsUserIdKey, string.Empty);
            if (string.IsNullOrEmpty(token) || string.IsNullOrEmpty(userId))
                return null;

            return new User()
            {
                AuthToken = _encryptionService.Decrypt(token),
                UserId = _encryptionService.Decrypt(userId)
            };
        }
    }
}