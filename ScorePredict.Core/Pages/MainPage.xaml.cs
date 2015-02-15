using System;
using Autofac;
using ScorePredict.Core.ViewModels;
using ScorePredict.Services.Contracts;

namespace ScorePredict.Core.Pages
{
    public partial class MainPage
    {
        public MainPage()
        {
            InitializeComponent();

            //BindingContext = ContainerHolder.Current.Resolve<MainPageViewModel>();
        }
    }
}
