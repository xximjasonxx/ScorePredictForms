using Android.Preferences;
using ScorePredict.Services.Contracts;
using Xamarin.Forms;

namespace ScorePredict.Droid.Impl
{
    public class DroidClearUserSecurityService : IClearUserSecurityService
    {
        #region IClearUserSecurityService implementation

        public void ClearUserSecurity()
        {
            var prefs = PreferenceManager.GetDefaultSharedPreferences(Forms.Context);
            var editor = prefs.Edit();

            var userId = prefs.GetString(AndroidConstants.SharedPrefsUserIdKey, string.Empty);
            if (!string.IsNullOrEmpty(userId))
                editor.Remove(AndroidConstants.SharedPrefsUserIdKey);

            var token = prefs.GetString(AndroidConstants.SharedPrefsTokenKey, string.Empty);
            if (!string.IsNullOrEmpty(token))
                editor.Remove(AndroidConstants.SharedPrefsTokenKey);


            var username = prefs.GetString(AndroidConstants.SharedPrefsUsernameKey, string.Empty);
            if (!string.IsNullOrEmpty(username))
                editor.Remove(AndroidConstants.SharedPrefsUsernameKey);

            editor.Commit();
        }

        #endregion
    }
}

