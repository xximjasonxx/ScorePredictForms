using System;
using Autofac;
using ScorePredict.Core.ViewModels;

namespace ScorePredict.Core.Pages
{
    public partial class CreateUserPage
    {
        public CreateUserPage()
        {
            InitializeComponent();
        }

        public override Type ViewModelType
        {
            get { return typeof (CreateUserPageViewModel); }
        }
    }
}
