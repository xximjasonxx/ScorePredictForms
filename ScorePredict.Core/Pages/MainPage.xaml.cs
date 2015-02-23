using System;
using System.Linq;
using Autofac;
using ScorePredict.Core.ViewModels;
using ScorePredict.Services.Contracts;
using Xamarin.Forms;

namespace ScorePredict.Core.Pages
{
    public partial class MainPage
    {
        public MainPage()
        {
            InitializeComponent();

            //BindingContext = ContainerHolder.Current.Resolve<MainPageViewModel>();
        }

        protected override void OnAppearing()
        {
            if (Device.OS == TargetPlatform.Android)
            {
                Children.Remove(Children.Last());       // remove about
                Children.Remove(Children.Last());       // remove history

                Children.Add((Page)Resources["ChromedHistoryPage"]);        // add history
                Children.Add((Page)Resources["ChromedAboutPage"]);  // add about
            }
        }
    }
}
