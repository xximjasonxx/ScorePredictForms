using Android.App;
using Android.OS;
using ScorePredict.Common.Injection;
using ScorePredict.Core;
using ScorePredict.Services;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

namespace ScorePredict.Droid
{
    [Activity(Label = "ScorePredict.Droid", MainLauncher = true, Icon = "@drawable/app_icon")]
    public class MainActivity : FormsApplicationActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            Forms.Init(this, bundle);

            // initialize dependency injection
            Resolver.CurrentResolver.Initialize(new ServiceInjectionModule(), new DroidInjectionModule());

            LoadApplication(new App());
        }
    }
}


