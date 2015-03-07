using System;
using ScorePredict.Core.ViewModels;

namespace ScorePredict.Core.Pages
{
    public partial class RankingsPage
    {
        public RankingsPage()
        {
            InitializeComponent();
        }

        public override Type ViewModelType
        {
            get { return typeof (RankingsPageViewModel); }
        }
    }
}
