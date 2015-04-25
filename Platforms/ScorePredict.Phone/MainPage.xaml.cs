using ScorePredict.Core;
using ScorePredict.Core.Contracts;
using ScorePredict.Core.Impl;
using ScorePredict.Phone.Modules;
using ScorePredict.Services.Modules;
using Xamarin.Forms;

namespace ScorePredict.Phone
{
    public partial class MainPage : IKillApplication
    {
        public MainPage()
        {
            InitializeComponent();

            Forms.Init();

            var app = new ScorePredictApplication(this, new ServiceInjectionModule(), new PhoneInjectionModule());
            LoadApplication(app);
        }

        public void KillApp()
        {
            App.Current.Terminate();
        }
    }
}