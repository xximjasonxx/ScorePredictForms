using System;
using ScorePredict.Common.Injection;
using ScorePredict.Services.Client;
using ScorePredict.Touch.Client;

namespace ScorePredict.Touch
{
    public class TouchInjectionModule : InjectionModule
    {
		public TouchInjectionModule(Xamarin.Forms.Application app)
        {
            AddDependency<IClient>(typeof(AzureMobileServiceClient));
			AddDependency<IApplicationHelper> (new TouchApplicationHelper(app));
        }
    }
}

