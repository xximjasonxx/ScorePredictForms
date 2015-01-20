using System;
using Autofac;
using ScorePredict.Common.Ex;
using ScorePredict.Core.ViewModels;
using ScorePredict.Services;
using ScorePredict.Services.Contracts;

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
