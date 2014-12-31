using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ScorePredict.Pages;
using Xamarin.Forms;

namespace ScorePredict
{
	public class App : Application
    {
		public App()
		{
			MainPage = new SplashPage ();
		}

		protected override void OnStart ()
		{
			base.OnStart ();
		}
    }
}
