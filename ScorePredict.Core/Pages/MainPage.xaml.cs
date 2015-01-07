using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ScorePredict.Common.Injection;
using ScorePredict.Services;
using Xamarin.Forms;

namespace ScorePredict.Core.Pages
{
    public partial class MainPage
    {
        private readonly IReadUserSecurityService _readUserSecurityService;

        public MainPage()
        {
            InitializeComponent();

            _readUserSecurityService = Resolver.CurrentResolver.Get<IReadUserSecurityService>();
        }

        protected override void OnAppearing()
        {
            var user = _readUserSecurityService.ReadUser();
            if (user == null)
            {
                Navigation.PushModalAsync(new NavigationPage(new LoginPage())
                {
                    BarBackgroundColor = Color.FromHex("#3C8513"),
                    BarTextColor = Color.FromHex("#FCD23C")
                }, true);
            }
        }
    }
}
