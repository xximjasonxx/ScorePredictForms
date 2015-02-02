using System;
using Autofac;
using ScorePredict.Core.ViewModels;
using Xamarin.Forms;

namespace ScorePredict.Core.Pages
{
    public abstract class ScorePredictContentPage : ContentPage
    {
        public abstract Type ViewModelType { get; }

        protected ScorePredictContentPage()
        {
            BindingContext = ContainerHolder.Current.Resolve(ViewModelType);
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            ((ViewModelBase) BindingContext).OnShow();
        }
    }
}
