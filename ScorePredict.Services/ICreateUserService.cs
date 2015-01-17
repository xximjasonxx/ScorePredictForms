using System.Threading.Tasks;
using ScorePredict.Common.Data;

namespace ScorePredict.Services
{
    public interface ICreateUserService
    {
        Task<User> CreateUserAsync(string username, string password, string confirm);
    }
}
