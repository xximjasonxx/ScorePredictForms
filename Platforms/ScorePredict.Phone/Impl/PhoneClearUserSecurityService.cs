using System.IO.IsolatedStorage;
using ScorePredict.Services.Contracts;

namespace ScorePredict.Phone.Impl
{
    public class PhoneClearUserSecurityService : IClearUserSecurityService
    {
        public void ClearUserSecurity()
        {
            IsolatedStorageSettings settings = IsolatedStorageSettings.ApplicationSettings;
            if (settings.Contains(PhoneConstants.SettingsUserIdKey))
                settings.Remove(PhoneConstants.SettingsUserIdKey);

            if (settings.Contains(PhoneConstants.SettingsTokenKey))
                settings.Remove(PhoneConstants.SettingsTokenKey);

            settings.Save();
        }
    }
}
