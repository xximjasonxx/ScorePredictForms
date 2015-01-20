using Autofac;
using ScorePredict.Core.ViewModels;

namespace ScorePredict.Core.Pages
{
    public partial class LoginPage
    {
        public LoginPage()
        {
            BindingContext = ContainerHolder.Current.Resolve<LoginPageViewModel>();
            InitializeComponent();
        }
    }
}
