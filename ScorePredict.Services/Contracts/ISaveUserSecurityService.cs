using ScorePredict.Common.Data;

namespace ScorePredict.Services.Contracts
{
    public interface ISaveUserSecurityService
    {
        void SaveUser(User user);
    }
}
