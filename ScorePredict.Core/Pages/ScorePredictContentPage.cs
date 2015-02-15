using System;
using System.Collections.Generic;
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
            var viewModel = GetViewModel(ViewModelType);
            OnViewModelResolved(viewModel);

            BindingContext = viewModel;
        }

        protected ScorePredictContentPage(IDictionary<string, string> parameters)
        {
            var viewModel = GetViewModel(ViewModelType);
            OnViewModelResolved(viewModel);
            ApplyViewModelParameters(viewModel, parameters);

            BindingContext = viewModel;
        }

        private ViewModelBase GetViewModel(Type type)
        {
            return (ViewModelBase)ContainerHolder.Current.Resolve(ViewModelType);
        }

        public virtual void OnViewModelResolved(ViewModelBase viewModel)
        {
            
        }

        public virtual void ApplyViewModelParameters(ViewModelBase viewModel, IDictionary<string, string> parameters)
        {
            
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            ((ViewModelBase) BindingContext).OnShow();
        }
    }
}
