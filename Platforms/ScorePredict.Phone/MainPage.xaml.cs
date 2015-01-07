using ScorePredict.Common.Injection;
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
            Resolver.CurrentResolver.Initialize(new ServiceInjectionModule(), new PhoneInjectionModule());
            LoadApplication(new Core.App());
        }
    }
}