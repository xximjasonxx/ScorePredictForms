using ScorePredict.Common.Injection;
using ScorePredict.Core.Contracts;
using ScorePredict.Services.Contracts;
using ScorePredict.Touch.Client;
using ScorePredict.Touch.Impl;
using UIKit;

namespace ScorePredict.Touch
{
    public class TouchInjectionModule : InjectionModule
    {
		public TouchInjectionModule(UIApplication app, IPageHelper pageHelper)
        {
            var windowHelper = new TouchWindowHelper(app);
            AddDependency<IClient>(new AzureMobileServiceClient(windowHelper));

			AddDependency<IEncryptionService> (typeof(TouchEncryptionService));
			AddDependency<IReadUserSecurityService>(typeof(TouchReadUserSecurityService));
			AddDependency<ISaveUserSecurityService>(typeof(TouchSaveUserSecurityService));
            AddDependency<IClearUserSecurityService>(typeof(TouchClearUserSecurityService));
            AddDependency<IDialogService>(typeof(TouchDialogService));
            AddDependency<IPageHelper>(pageHelper);
        }
    }
}

