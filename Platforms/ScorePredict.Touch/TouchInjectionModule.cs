using System;
using ScorePredict.Common.Injection;
using ScorePredict.Services.Client;
using ScorePredict.Touch.Client;
using MonoTouch.UIKit;
using ScorePredict.Services;

namespace ScorePredict.Touch
{
    public class TouchInjectionModule : InjectionModule
    {
		public TouchInjectionModule(UIApplication app)
        {
            var windowHelper = new TouchWindowHelper(app);

			AddDependency<IClient>(new AzureMobileServiceClient(
                windowHelper, new ProgressHudProgressIndicatorService(windowHelper)));

			AddDependency<IEncryptionService> (typeof(TouchEncryptionService));
			AddDependency<IReadUserSecurityService>(typeof(TouchReadUserSecurityService));
			AddDependency<ISaveUserSecurityService>(typeof(TouchSaveUserSecurityService));
            AddDependency<IClearUserSecurityService>(typeof(TouchClearUserSecurityService));
        }
    }
}

