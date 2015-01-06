using MonoTouch.UIKit;
using ScorePredict.Core.Controls;
using ScorePredict.Touch.Rendering;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(ScorePredictEntry), typeof(TouchScorePredictEntryRenderer))]

namespace ScorePredict.Touch.Rendering
{
    public class TouchScorePredictEntryRenderer : EntryRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.Entry> e)
        {
            base.OnElementChanged(e);

            if (Control != null)
            {
                Control.TextColor = UIColor.Black;
            }
        }
    }
}

