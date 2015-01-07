using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ScorePredict.Core.Pages;
using Xamarin.Forms;

namespace ScorePredict.Core
{
    public class App : Application
    {
        public App()
        {
            MainPage = new MainPage();
        }
    }
}
