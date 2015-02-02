using System;
using ScorePredict.Core.ViewModels;

namespace ScorePredict.Core.Pages
{
    public partial class AboutPage
    {
        public AboutPage()
        {
            InitializeComponent();
        }

        public override Type ViewModelType
        {
            get { return typeof (AboutPageViewModel); }
        }
    }
}
