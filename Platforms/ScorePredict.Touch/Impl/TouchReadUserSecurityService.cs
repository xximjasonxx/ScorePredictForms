using Foundation;
using ScorePredict.Common.Data;
using ScorePredict.Common.Injection;
using ScorePredict.Core.Contracts;
using ScorePredict.Services.Contracts;

namespace ScorePredict.Touch.Impl
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
