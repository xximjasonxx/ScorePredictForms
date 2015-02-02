using System;
using ScorePredict.Core.ViewModels;

namespace ScorePredict.Core.Pages
{
    public partial class HistoryPage
    {
        public HistoryPage()
        {
            InitializeComponent();
        }

        public override Type ViewModelType
        {
            get { return typeof (HistoryPageViewModel); }
        }
    }
}
