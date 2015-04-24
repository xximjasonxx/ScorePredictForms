using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using ScorePredict.Phone.Rendering;
using Xamarin.Forms;
using Xamarin.Forms.Platform.WinPhone;
using Color = Windows.UI.Color;

[assembly: ExportRenderer(typeof(ActivityIndicator), typeof(PhoneActivityIndicatorRenderer))]
namespace ScorePredict.Phone.Rendering
{
    public class PhoneActivityIndicatorRenderer : ActivityIndicatorRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<ActivityIndicator> e)
        {
            base.OnElementChanged(e);
            if (e.OldElement == null)
            {
                SolidColorBrush yellowColor = (SolidColorBrush) App.Current.Resources["YellowColor"];
                this.Control.Foreground = yellowColor;
            }
        }
    }
}
