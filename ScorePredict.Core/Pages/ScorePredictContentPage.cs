using System;
using System.Collections.Generic;
using Autofac;
using ScorePredict.Core.ViewModels;
using ScorePredict.Core.ViewModels.Abstract;
using Xamarin.Forms;

namespace ScorePredict.Core.Pages
{
    public abstract class ScorePredictContentPage : ContentPage
    {
        public static BindableProperty MenuItemsProperty =
            BindableProperty.Create<ScorePredictContentPage, IList<ToolbarItem>>(x => x.MenuItems, default(IList<ToolbarItem>),
                BindingMode.OneWay, null, OnMenuItemsChanged);

        public IList<ToolbarItem> MenuItems
        {
            get { return (IList<ToolbarItem>) GetValue(MenuItemsProperty); }
            set {  SetValue(MenuItemsProperty, value);}
        }

        private static void OnMenuItemsChanged(BindableObject bindable, IList<ToolbarItem> oldvalue, IList<ToolbarItem> newvalue)
        {
            var page = bindable as ContentPage;
            if (page != null)
            {
                page.ToolbarItems.Clear();
                foreach (var item in newvalue)
                {
                    page.ToolbarItems.Add(item);
                }
            }
        }

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

            ((ViewModelBase) BindingContext).BuildMenu();
            ((ViewModelBase) BindingContext).OnShow();
        }

        protected override bool OnBackButtonPressed()
        {
            return _viewModel.BackButtonPressed(); ;
        }
    }
}
