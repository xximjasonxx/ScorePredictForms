using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScorePredict.Services
{
    public interface ISetUsernameService
    {
        Task<string> SetUsernameForUserAsync(string userId, string username);
    }
}
