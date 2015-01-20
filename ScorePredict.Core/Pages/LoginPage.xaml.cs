using Autofac;
using ScorePredict.Core.ViewModels;

namespace ScorePredict.Core.Pages
{
    public partial class LoginPage
    {
        

        public LoginPage()
        {
            InitializeComponent();
            BindingContext = ContainerHolder.Current.Resolve<LoginPageViewModel>();
        }
    }
}
