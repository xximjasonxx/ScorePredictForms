using ScorePredict.Core.Pages;
using Xamarin.Forms;

namespace ScorePredict.Core
{
    public class App : Application
    {
        public App()
        {
            MainPage = new NavigationPage(new MainPage())
            {
                BarBackgroundColor = Color.FromHex("#3C8513"),
                BarTextColor = Color.FromHex("#FCD23C")
            };
        }
    }
}
