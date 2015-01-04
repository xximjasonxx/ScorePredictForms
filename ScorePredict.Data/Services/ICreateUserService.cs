using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScorePredict.Data.Services
{
    public interface ICreateUserService
    {
        Task<bool> CreateUserAsync(string username, string password, string confirm);
    }
}
