using ScorePredict.Core.Controls;
using ScorePredict.Touch.Rendering;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(NumberEntry), typeof(NumberEntryRenderer))]
namespace ScorePredict.Touch.Rendering
{
    public class NumberEntryRenderer : EntryRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);

            if (Control != null)
            {
                Control.KeyboardType = UIKeyboardType.NumberPad;
            }
        }
    }
}