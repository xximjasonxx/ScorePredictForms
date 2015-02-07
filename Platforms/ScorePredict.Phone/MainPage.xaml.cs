using ScorePredict.Core;
using ScorePredict.Core.Impl;
using ScorePredict.Phone.Modules;
using ScorePredict.Services.Modules;
using Xamarin.Forms;

namespace ScorePredict.Phone
{
    public partial class MainPage
    {
        public MainPage()
        {
            InitializeComponent();

            Forms.Init();

            var app = new ScorePredictApplication(new PhoneNavigator(),
                new ServiceInjectionModule(), new PhoneInjectionModule());
            LoadApplication(app);
        }
    }
}