using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using ScorePredict.Common.Injection;
using ScorePredict.Phone.Resources;
using ScorePredict.Services;
using Xamarin.Forms;

namespace ScorePredict.Phone
{
    public partial class MainPage
    {
        public MainPage()
        {
            InitializeComponent();

            Forms.Init();
            Resolver.CurrentResolver.Initialize(new ServiceInjectionModule());
            LoadApplication(new Core.App());
        }
    }
}