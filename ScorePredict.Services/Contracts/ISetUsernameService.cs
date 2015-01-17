using System.Threading.Tasks;

namespace ScorePredict.Services.Contracts
{
    public interface ISetUsernameService
    {
        Task<string> SetUsernameForUserAsync(string userId, string username);
    }
}
