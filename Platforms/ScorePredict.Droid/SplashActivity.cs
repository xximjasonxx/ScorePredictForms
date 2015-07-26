using Android.App;
using Android.OS;

namespace ScorePredict.Droid
{
    [Activity(Label = "Score Predict", Icon = "@drawable/app_icon", Theme = "@style/Theme.SplashTheme", MainLauncher = true)]
    public class SplashActivity : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Create your application here
            StartActivity(typeof(MainActivity));
            Finish();
        }
    }
}