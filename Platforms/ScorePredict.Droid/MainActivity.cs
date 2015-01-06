using System;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Xamarin.Forms.Platform.Android;
using ScorePredict.Common.Injection;
using ScorePredict.Core;
using ScorePredict.Services;

namespace ScorePredict.Droid
{
    [Activity(Label = "ScorePredict.Droid", MainLauncher = true, Icon = "@drawable/app_icon")]
    public class MainActivity : FormsApplicationActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            Xamarin.Forms.Forms.Init(this, bundle);

            // initialize dependency injection
            Resolver.CurrentResolver.Initialize(new ServiceInjectionModule(), new DroidInjectionModule());

            LoadApplication(new App());
        }
    }
}


