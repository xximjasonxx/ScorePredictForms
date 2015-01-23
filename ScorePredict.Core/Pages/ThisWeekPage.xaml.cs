using Autofac;
using ScorePredict.Core.ViewModels;
using Xamarin.Forms;

namespace ScorePredict.Core.Pages
{
    public partial class ThisWeekPage : ContentPage
    {
        public ThisWeekPage()
        {
            InitializeComponent();
            BindingContext = ContainerHolder.Current.Resolve<ThisWeekPageViewModel>();
        }
    }
}
