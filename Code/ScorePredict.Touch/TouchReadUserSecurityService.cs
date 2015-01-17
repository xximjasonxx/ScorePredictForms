using System;
using System.Collections.Generic;
using System.Text;
using MonoTouch.Foundation;
using ScorePredict.Common.Injection;
using ScorePredict.Data;
using ScorePredict.Services;

namespace ScorePredict.Touch
{
    public class TouchReadUserSecurityService : IReadUserSecurityService
    {
        private readonly IEncryptionService _encryptionService;

        public TouchReadUserSecurityService()
        {
            _encryptionService = Resolver.CurrentResolver.Get<IEncryptionService>();
        }

        public User ReadUser()
        {
            var defaults = NSUserDefaults.StandardUserDefaults;
            var userIdString = defaults.StringForKey(TouchConstants.UserIdKey);
            var tokenString = defaults.StringForKey(TouchConstants.TokenKey);

            if (string.IsNullOrEmpty(userIdString) || string.IsNullOrEmpty(tokenString))
                return null;

            return new User()
            {
                AuthToken = _encryptionService.Decrypt(tokenString),
                UserId = _encryptionService.Decrypt(userIdString)
            };
        }
    }
}
