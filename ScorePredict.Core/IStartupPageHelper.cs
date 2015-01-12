using System;
using Xamarin.Forms;
using ScorePredict.Data;

namespace ScorePredict.Core
{
    public interface IStartupPageHelper
    {
        Page GetMainPage();
        Page GetLoginPage();
        Page GetUsernamePage(User user);
    }
}

