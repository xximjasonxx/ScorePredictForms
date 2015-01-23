using Autofac;
using ScorePredict.Common.Data;
using ScorePredict.Core.ViewModels;

namespace ScorePredict.Core.Pages
{
    public partial class EnterUsernamePage
    {
        private User _theUser;

        public EnterUsernamePage(User user)
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            ViewModel.User = _theUser;
        }
    }
}
