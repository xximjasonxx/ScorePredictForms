using System;
using ScorePredict.Common.Injection;
using ScorePredict.Services.Client;
using ScorePredict.Touch.Client;
using MonoTouch.UIKit;

namespace ScorePredict.Touch
{
    public class TouchInjectionModule : InjectionModule
    {
		public TouchInjectionModule(UIApplication app)
        {
            AddDependency<IClient>(typeof(AzureMobileServiceClient));
            AddDependency<IWindowHelper> (new TouchWindowHelper(app));
        }
    }
}

