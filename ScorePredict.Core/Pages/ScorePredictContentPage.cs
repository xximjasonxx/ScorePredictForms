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

        private ViewModelBase _viewModel;

        protected ScorePredictContentPage()
        {
            _viewModel = GetViewModel(ViewModelType);
            OnViewModelResolved(_viewModel);

            BindingContext = _viewModel;
        }

        protected ScorePredictContentPage(IDictionary<string, string> parameters)
        {
            _viewModel = GetViewModel(ViewModelType);
            OnViewModelResolved(_viewModel);
            ApplyViewModelParameters(_viewModel, parameters);

            BindingContext = _viewModel;
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

        protected override bool OnBackButtonPressed()
        {
            return _viewModel.BackButtonPressed(); ;
        }
    }
}
