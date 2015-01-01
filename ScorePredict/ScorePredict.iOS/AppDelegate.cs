using System;
using System.Collections.Generic;
using System.Linq;

using MonoTouch.Foundation;
using MonoTouch.UIKit;

using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
using ScorePredict.Pages;

namespace ScorePredict.iOS
{
    // The UIApplicationDelegate for the application. This class is responsible for launching the 
    // User Interface of the application, as well as listening (and optionally responding) to 
    // application events from iOS.
    [Register("AppDelegate")]
    public partial class AppDelegate : FormsApplicationDelegate
    {
        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            Forms.Init();

			//window = new UIWindow(UIScreen.MainScreen.Bounds);

			//window.RootViewController = new SplashPage().CreateViewController();
			LoadApplication (new App ());

			return base.FinishedLaunching (app, options);
        }
    }
}
