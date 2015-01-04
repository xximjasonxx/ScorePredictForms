using System.Threading.Tasks;
using ScorePredict.Data.Entity;

namespace ScorePredict.Data.Services
{
    public interface ICreateUserService
    {
        Task<User> CreateUserAsync(string username, string password, string confirm);
    }
}
