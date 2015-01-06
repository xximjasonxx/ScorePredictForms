using System;
using System.Threading.Tasks;
using ScorePredict.Data;

namespace ScorePredict.Services
{
    public interface ILoginUserService
    {
        Task<User> LoginAsync(string username, string password);
        Task<User> LoginWithFacebookAsync();
    }
}

