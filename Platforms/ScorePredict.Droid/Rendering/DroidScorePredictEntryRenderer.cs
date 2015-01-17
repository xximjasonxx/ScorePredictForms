using Android.Graphics;
using ScorePredict.Core.Controls;
using ScorePredict.Droid.Rendering;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(ScorePredictEntry), typeof(DroidScorePredictEntryRenderer))]

namespace ScorePredict.Droid.Rendering
{
    public class DroidScorePredictEntryRenderer : EntryRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);

            if (Control != null)
            {
                Control.SetTextColor(Android.Graphics.Color.White);
                Control.SetHintTextColor(Android.Graphics.Color.Argb(0xff, 0xFC, 0xD2, 0x3C));
            }
        }
    }
}

