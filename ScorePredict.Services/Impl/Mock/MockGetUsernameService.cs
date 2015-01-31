using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScorePredict.Services.Impl.Mock
{
    public class MockGetUsernameService : IGetUsernameService
    {
        public async Task<string> GetUsernameAsync(string userId)
        {
            return "xximjasonxx";
        }
    }
}
