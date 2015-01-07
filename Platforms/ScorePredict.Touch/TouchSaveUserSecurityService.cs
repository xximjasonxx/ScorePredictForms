using System;
using MonoTouch.Foundation;
using ScorePredict.Common.Injection;
using ScorePredict.Data;
using ScorePredict.Services;

namespace ScorePredict.Touch
{
    public class TouchSaveUserSecurityService : ISaveUserSecurityService
    {
        private readonly IEncryptionService _encryptionService;

        public TouchSaveUserSecurityService()
        {
            _encryptionService = Resolver.CurrentResolver.Get<IEncryptionService>();
        }
        public void SaveUser(User user)
        {
            var defaults = NSUserDefaults.StandardUserDefaults;
            defaults[TouchConstants.UserIdKey] = new NSString(_encryptionService.Encrypt(user.UserId));
            defaults[TouchConstants.TokenKey] = new NSString(_encryptionService.Encrypt(user.AuthToken));

            defaults.Synchronize();
        }
    }
}
