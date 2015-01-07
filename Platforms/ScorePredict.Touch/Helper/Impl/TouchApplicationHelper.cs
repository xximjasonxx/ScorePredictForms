using System;

namespace ScorePredict.Touch
{
	public class TouchApplicationHelper : IApplicationHelper
	{
		#region IApplicationHelper implementation

		public Xamarin.Forms.Application Application { get; private set; }

		#endregion


		public TouchApplicationHelper (Xamarin.Forms.Application app)
		{
			Application = app;
		}
	}
}

