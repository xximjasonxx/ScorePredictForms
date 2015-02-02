using System;
using ScorePredict.Core.ViewModels;

namespace ScorePredict.Core.Pages
{
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
