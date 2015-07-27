using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ScorePredict.Core.Controls
{
    public class ContentLoader : ContentView
    {
        public static BindableProperty MessageProperty =
            BindableProperty.Create<ContentLoader, string>(x => x.Message, null);

        public string Message
        {
            get { return GetValue(MessageProperty) as string; }
            set { SetValue(MessageProperty, value); }
        }
    }
}
