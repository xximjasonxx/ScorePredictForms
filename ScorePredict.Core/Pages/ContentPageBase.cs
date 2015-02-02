using Autofac;
using ScorePredict.Core.ViewModels;
using Xamarin.Forms;

namespace ScorePredict.Core.Pages
{
    public class ContentPageBase<T> : ContentPage where T : ViewModelBase
    {
        public T ViewModel
        {
            get { return (T) BindingContext; }
        }

        protected ContentPageBase()
        {
            var vm = ContainerHolder.Current.Resolve<T>();
            BindingContext = vm;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            ((T) BindingContext).OnShow();
        }
    }
}
