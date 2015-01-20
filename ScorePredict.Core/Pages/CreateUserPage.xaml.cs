using Autofac;
using ScorePredict.Core.ViewModels;

namespace ScorePredict.Core.Pages
{
    public partial class CreateUserPage
    {
        public CreateUserPage()
        {
            InitializeComponent();
            BindingContext = ContainerHolder.Current.Resolve<CreateUserPageViewModel>();
        }
    }
}
