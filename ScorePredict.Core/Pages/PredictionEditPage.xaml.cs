using System;
using ScorePredict.Common.Data;
using ScorePredict.Core.ViewModels;

namespace ScorePredict.Core.Pages
{
    public partial class PredictionEditPage
    {
        private readonly Prediction _prediction;

        public PredictionEditPage(Prediction prediction)
        {
            InitializeComponent();

            _prediction = prediction;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            ((PredictionEditViewModel) BindingContext).Prediction = _prediction;
        }

        public override Type ViewModelType
        {
            get { return typeof (PredictionEditViewModel); }
        }
    }
}
