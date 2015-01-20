using Foundation;
using ScorePredict.Common.Data;
using ScorePredict.Core.Contracts;
using ScorePredict.Services.Contracts;

namespace ScorePredict.Touch.Impl
{
    public class TouchSaveUserSecurityService : ISaveUserSecurityService
    {
        public IEncryptionService EncryptionService { get; private set; }

        public TouchSaveUserSecurityService(IEncryptionService encryptionService)
        {
            EncryptionService = encryptionService;
        }

        public void SaveUser(User user)
        {
            var defaults = NSUserDefaults.StandardUserDefaults;
            defaults[TouchConstants.UserIdKey] = new NSString(EncryptionService.Encrypt(user.UserId));
            defaults[TouchConstants.TokenKey] = new NSString(EncryptionService.Encrypt(user.AuthToken));
            defaults[TouchConstants.UsernameKey] = new NSString(user.Username);

            defaults.Synchronize();
        }
    }
}
