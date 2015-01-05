using System;
using Xamarin.Forms.Platform.iOS;
using MonoTouch.UIKit;
using Xamarin.Forms;
using ScorePredict.Touch;
using ScorePredict.Core.Controls;

[assembly: ExportRenderer(typeof(ScorePredictEntry), typeof(TouchScorePredictEntryRenderer))]

namespace ScorePredict.Touch
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

