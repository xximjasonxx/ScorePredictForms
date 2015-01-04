using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using ScorePredict.Injection;
using ScorePredict.WinPhone.Module;
using Xamarin.Forms;
using Xamarin.Forms.Platform.WinPhone;


namespace ScorePredict.WinPhone
{
    public partial class MainPage
    {
        public MainPage()
        {
            InitializeComponent();

            Forms.Init();
            Resolver.CurrentResolver.Initialize(new WindowsPhoneInjectionModule());
            LoadApplication(new ScorePredict.App());
        }
    }
}
