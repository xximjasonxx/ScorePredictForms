using System;
using System.Collections.Generic;
using System.Linq;

using Foundation;
using Microsoft.WindowsAzure.MobileServices;
using ScorePredict.Core;
using ScorePredict.Core.Impl;
using ScorePredict.Services.Modules;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

namespace ScorePredict.Touch
{
    [Register("AppDelegate")]
    public partial class AppDelegate : FormsApplicationDelegate
    {
        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            Forms.Init();
            CurrentPlatform.Init();

            LoadApplication(new ScorePredictApplication(new MainPageWithModalStartupPageHelper(),
                new ServiceInjectionModule(),
                new TouchInjectionModule(app)));

            return base.FinishedLaunching(app, options);
        }
    }
}