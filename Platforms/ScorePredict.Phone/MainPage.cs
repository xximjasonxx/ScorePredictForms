
using ScorePredict.Common.Injection;
using ScorePredict.Core;
using ScorePredict.Services;
using Xamarin.Forms;

namespace ScorePredict.Phone
{
    public partial class MainPage
    {
        public MainPage()
        {
            InitializeComponent();

            Forms.Init();

            var app = new Core.App(new ServiceInjectionModule(),
                new PhoneInjectionModule(new PhonePageHelper()));
            LoadApplication(app);

            // add in the special injection module for windows phone navigation
            Resolver.CurrentResolver.AddModule(new PhoneNavigationModule(app.MainPage.Navigation));
        }
    }
}