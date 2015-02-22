using System;
using Autofac;
using ScorePredict.Core.Contracts;
using ScorePredict.Core.ViewModels;

namespace ScorePredict.Core.Pages
{
    public partial class LoginPage
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        public override Type ViewModelType
        {
            get { return typeof (LoginPageViewModel); }
        }

        protected override bool OnBackButtonPressed()
        {
            ContainerHolder.Current.Resolve<IKillApplication>().KillApp();
            return true;
        }
    }
}
