using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ScorePredict.Core.Pages
{
    public partial class MainPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            Navigation.PushModalAsync(new NavigationPage(new LoginPage())
            {
                BarBackgroundColor = Color.FromHex("#3C8513")
            }, true);
        }
    }
}
