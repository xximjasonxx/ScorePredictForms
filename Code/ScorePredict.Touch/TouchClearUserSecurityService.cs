using System;
using ScorePredict.Services;
using MonoTouch.Foundation;

namespace ScorePredict.Touch
{
    public class TouchClearUserSecurityService : IClearUserSecurityService
    {
        #region IClearUserSecurityService implementation

        public void ClearUserSecurity()
        {
            var defaults = NSUserDefaults.StandardUserDefaults;
            if (defaults.ValueForKey(new NSString(TouchConstants.UserIdKey)) != null)
                defaults.RemoveObject(TouchConstants.UserIdKey);

            if (defaults.ValueForKey(new NSString(TouchConstants.TokenKey)) != null)
                defaults.RemoveObject(TouchConstants.TokenKey);

            defaults.Synchronize();
        }

        #endregion
    }
}

