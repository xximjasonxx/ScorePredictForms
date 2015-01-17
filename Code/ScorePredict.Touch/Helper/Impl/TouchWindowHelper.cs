using System;
using MonoTouch.UIKit;

namespace ScorePredict.Touch
{
    public class TouchWindowHelper : IWindowHelper
	{
        private readonly UIApplication _application;

        public TouchWindowHelper (UIApplication app)
		{
            _application = app;
		}

        #region IWindowHelper implementation

        public UIWindow GetKeyWindow()
        {
            if (_application.KeyWindow == null)
                throw new InvalidOperationException("Cannot reference KeyWindow before it is set");

            return _application.KeyWindow;
        }

        #endregion
	}
}

