using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using ScorePredict.Core;
using ScorePredict.Core.Contracts;
using ScorePredict.Core.Impl;
using ScorePredict.Services.Modules;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

namespace ScorePredict.Droid
{
    [Activity(Label = "Score Predict", MainLauncher = true, Icon = "@drawable/app_icon", Theme = "@style/Theme.Maintheme")]
    public class MainActivity : FormsApplicationActivity, IPageHelper
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            Forms.Init(this, bundle);

            LoadApplication(new ScorePredictApplication(new StandardStartupPageHelper(),
                new ServiceInjectionModule(), new DroidInjectionModule(this)));
        }

        public void ShowLogin()
        {
            SetPage(PageFactory.GetLoginPage());
        }

        public void ShowMain()
        {
            SetPage(PageFactory.GetHomePage());
        }
    }
}

