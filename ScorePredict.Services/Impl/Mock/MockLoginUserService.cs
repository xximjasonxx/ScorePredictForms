using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ScorePredict.Common.Data;

namespace ScorePredict.Services.Impl.Mock
{
    public class MockLoginUserService : ILoginUserService
    {
        public async Task<User> LoginAsync(string username, string password)
        {
            return new User()
            {
                AuthToken = "MyAuthToken",
                Username = "MyUsername",
                UserId = "MyUserId"
            };
        }

        public async Task<User> LoginWithFacebookAsync()
        {
            return new User()
            {
                AuthToken = "MyAuthToken",
                Username = "MyUsername",
                UserId = "MyUserId"
            };
        }

        public async Task<bool> CheckUserTokenAsync()
        {
            return true;
        }
    }
}
