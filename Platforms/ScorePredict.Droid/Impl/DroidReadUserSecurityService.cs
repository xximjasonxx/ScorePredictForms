using Android.Preferences;
using ScorePredict.Common.Data;
using ScorePredict.Common.Injection;
using ScorePredict.Core.Contracts;
using ScorePredict.Droid.Impl;
using ScorePredict.Services.Contracts;
using Xamarin.Forms;

[assembly: Dependency(typeof(DroidReadUserSecurityService))]

namespace ScorePredict.Droid.Impl
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

            var username = prefs.GetString(AndroidConstants.SharedPrefsUsernameKey, string.Empty);
            return new User()
            {
                AuthToken = _encryptionService.Decrypt(token),
                UserId = _encryptionService.Decrypt(userId),
                Username = username
            };
        }
    }
}