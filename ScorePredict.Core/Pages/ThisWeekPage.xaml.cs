using System;
using ScorePredict.Core.ViewModels;
using Xamarin.Forms;

namespace ScorePredict.Core.Pages
{
    public class ScorePredictNavigationPage : NavigationPage
    {
        public ScorePredictNavigationPage(Page page) : base(page)
        {
            BarBackgroundColor = Color.FromHex("#3C8513");
            BarTextColor = Color.FromHex("#FCD23C");
        }
    }

    public partial class ThisWeekPage
    {
        public ThisWeekPage()
        {
            InitializeComponent();
        }

        public override Type ViewModelType
        {
            get { return typeof (ThisWeekPageViewModel); }
        }
    }
}
