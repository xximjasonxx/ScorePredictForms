using Acr.UserDialogs;
using Android.App;
using Android.OS;
using ScorePredict.Core;
using ScorePredict.Core.Contracts;
using ScorePredict.Services.Modules;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

namespace ScorePredict.Droid
{
    [Activity(Label = "Score Predict", Icon = "@drawable/app_icon", Theme = "@style/Theme.Maintheme")]
    public class MainActivity : FormsApplicationActivity, IKillApplication
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            Forms.Init(this, bundle);
            UserDialogs.Init(this);

            LoadApplication(new ScorePredictApplication(this, new ServiceInjectionModule(), new DroidInjectionModule()));
        }

        public void KillApp()
        {
            Process.KillProcess(Android.OS.Process.MyPid());
        }
    }
}

