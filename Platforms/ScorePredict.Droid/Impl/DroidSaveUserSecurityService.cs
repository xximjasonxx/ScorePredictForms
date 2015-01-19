using Android.Preferences;
using ScorePredict.Common.Data;
using ScorePredict.Core.Contracts;
using ScorePredict.Droid.Impl;
using ScorePredict.Services.Contracts;
using Xamarin.Forms;

[assembly: Dependency(typeof(DroidSaveUserSecurityService))]

namespace ScorePredict.Droid.Impl
{
    public class DroidSaveUserSecurityService : ISaveUserSecurityService
    {
        public IEncryptionService EncryptionService { get; set; }

        public void SaveUser(User user)
        {
            var editor = PreferenceManager.GetDefaultSharedPreferences(Forms.Context).Edit();
            editor.PutString(AndroidConstants.SharedPrefsUserIdKey, 
                EncryptionService.Encrypt(user.UserId));
            editor.PutString(AndroidConstants.SharedPrefsTokenKey,
                EncryptionService.Encrypt(user.AuthToken));
            editor.PutString(AndroidConstants.SharedPrefsUsernameKey,
                user.Username);
            editor.Commit();
        }
    }
}