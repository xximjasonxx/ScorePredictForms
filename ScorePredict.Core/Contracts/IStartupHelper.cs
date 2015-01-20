using ScorePredict.Common.Data;
using Xamarin.Forms;

namespace ScorePredict.Core.Contracts
{
    public interface IStartupHelper
    {
        Page GetMainPage();
        Page GetLoginPage();
        Page GetUsernamePage(User user);
    }
}

