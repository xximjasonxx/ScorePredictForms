using System;
using ScorePredict.Common.Injection;
using ScorePredict.Services.Client;
using ScorePredict.Touch.Client;
using MonoTouch.UIKit;
using ScorePredict.Services;
using Acr.XamForms.UserDialogs;
using Acr.XamForms.UserDialogs.iOS;
using ScorePredict.Core;

namespace ScorePredict.Touch
{
    public class TouchInjectionModule : InjectionModule
    {
		public TouchInjectionModule(UIApplication app, IPageHelper pageHelper)
        {
            var windowHelper = new TouchWindowHelper(app);
            var userDialogService = new UserDialogService();

			AddDependency<IClient>(new AzureMobileServiceClient(
                windowHelper, userDialogService));

			AddDependency<IEncryptionService> (typeof(TouchEncryptionService));
			AddDependency<IReadUserSecurityService>(typeof(TouchReadUserSecurityService));
			AddDependency<ISaveUserSecurityService>(typeof(TouchSaveUserSecurityService));
            AddDependency<IClearUserSecurityService>(typeof(TouchClearUserSecurityService));
            AddDependency<IUserDialogService>(userDialogService);
            AddDependency<IPageHelper>(pageHelper);
        }
    }
}

