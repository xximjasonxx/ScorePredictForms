using System.Threading;
using Xamarin.Forms;

namespace ScorePredict.Pages
{	
	public partial class SplashPage
	{	
		public SplashPage ()
		{
			InitializeComponent ();
		}

	    protected override void OnAppearing()
	    {
	        Navigation.PushModalAsync(new NavigationPage(new LoginPage())
	        {
                BarBackgroundColor = Color.FromHex("#3C8513"),
                Title = "Login"
	        }, true);
	    }
	}
}

