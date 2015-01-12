using System;
using System.Collections.Generic;
using System.Linq;

using MonoTouch.Foundation;
using MonoTouch.UIKit;
using Xamarin.Forms.Platform.iOS;
using Xamarin.Forms;
using ScorePredict.Core;
using ScorePredict.Common.Injection;
using ScorePredict.Services;
using Microsoft.WindowsAzure.MobileServices;

namespace ScorePredict.Touch
{
    [Register("AppDelegate")]
    public partial class AppDelegate : FormsApplicationDelegate
    {
		public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            Forms.Init();
            CurrentPlatform.Init();
			
            LoadApplication(new App(new MainPageWithModalGetMainPage(),
                new ServiceInjectionModule(),
                new TouchInjectionModule(app, new TouchPageHelper())));

            return base.FinishedLaunching (app, options);
        }
    }
}

