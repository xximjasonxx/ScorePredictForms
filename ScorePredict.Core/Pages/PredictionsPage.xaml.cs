using System;
using ScorePredict.Core.ViewModels;

namespace ScorePredict.Core.Pages
{
    public partial class PredictionsPage
    {
        public PredictionsPage()
        {
            InitializeComponent();
        }

        public override Type ViewModelType
        {
            get { return typeof (PredictionsPageViewModel); }
        }
    }
}
