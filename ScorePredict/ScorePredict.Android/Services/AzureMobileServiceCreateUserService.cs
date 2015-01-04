using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using ScorePredict.Data.Ex;
using ScorePredict.Data.Services;

namespace ScorePredict.Droid.Services
{
    public class AzureMobileServiceCreateUserService : ICreateUserService
    {
        public Task<bool> CreateUserAsync(string username, string password, string confirm)
        {
            throw new CreateUserException("Testing");
        }
    }
}