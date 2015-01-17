using ScorePredict.Common.Data;
using Xamarin.Forms;

namespace ScorePredict.Core.Contracts
{
    public interface IStartupPageHelper
    {
        Page GetMainPage();
        Page GetLoginPage();
        Page GetUsernamePage(User user);
    }
}

