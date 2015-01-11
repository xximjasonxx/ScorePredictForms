using System;
using System.Collections.Generic;
using System.IO.IsolatedStorage;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ScorePredict.Services;

namespace ScorePredict.Phone
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
