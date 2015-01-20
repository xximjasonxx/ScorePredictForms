using Autofac;
using ScorePredict.Common.Data;
using ScorePredict.Core.ViewModels;

namespace ScorePredict.Core.Pages
{
    public partial class EnterUsernamePage
    {
        public EnterUsernamePage(User user)
        {
            InitializeComponent();
            var viewModel = ContainerHolder.Current.Resolve<EnterUsernamePageViewModel>();
            viewModel.User = user;
            BindingContext = viewModel;
        }
    }
}
