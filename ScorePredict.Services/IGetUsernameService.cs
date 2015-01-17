using System.Threading.Tasks;

namespace ScorePredict.Services
{
    public interface IGetUsernameService
    {
        Task<string> GetUsernameAsync(string userId);
    }
}
