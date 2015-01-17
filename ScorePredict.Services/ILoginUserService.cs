using System.Threading.Tasks;
using ScorePredict.Common.Data;

namespace ScorePredict.Services
{
    public interface ILoginUserService
    {
        Task<User> LoginAsync(string username, string password);
        Task<User> LoginWithFacebookAsync();
    }
}

