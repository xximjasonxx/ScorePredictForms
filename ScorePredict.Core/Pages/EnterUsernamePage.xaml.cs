using System;
using Autofac;
using ScorePredict.Common.Data;
using ScorePredict.Core.ViewModels;

namespace ScorePredict.Core.Pages
{
    public partial class EnterUsernamePage
    {
        private readonly User _theUser;

        public EnterUsernamePage(User user)
        {
            InitializeComponent();
            _theUser = user;
        }

        public override Type ViewModelType
        {
            get { return typeof (EnterUsernamePageViewModel); }
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            ((EnterUsernamePageViewModel) BindingContext).User = _theUser;
        }
    }
}
