using ScorePredict.Core.Controls;
using ScorePredict.Touch.Rendering;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(ScorePredictEntry), typeof(TouchScorePredictEntryRenderer))]

namespace ScorePredict.Touch.Rendering
{
    public class TouchScorePredictEntryRenderer : EntryRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);

            if (e.OldElement == null)
            {
                Control.TextColor = UIColor.Black;
            }

            /*if (e.NewElement != null)
            {
                Control.Enabled = e.NewElement.IsEnabled;
            }*/
        }
    }
}

