using Foundation;
using ScorePredict.Common.Data;
using ScorePredict.Core.Contracts;
using ScorePredict.Services.Contracts;

namespace ScorePredict.Touch.Impl
{
    public class TouchReadUserSecurityService : IReadUserSecurityService
    {
        public IEncryptionService EncryptionService { get; set; }

        public User ReadUser()
        {
            var defaults = NSUserDefaults.StandardUserDefaults;
            var userIdString = defaults.StringForKey(TouchConstants.UserIdKey);
            var tokenString = defaults.StringForKey(TouchConstants.TokenKey);

            if (string.IsNullOrEmpty(userIdString) || string.IsNullOrEmpty(tokenString))
                return null;

            var username = defaults.StringForKey(TouchConstants.UsernameKey);
            return new User()
            {
                AuthToken = EncryptionService.Decrypt(tokenString),
                UserId = EncryptionService.Decrypt(userIdString),
                Username = username
            };
        }
    }
}
