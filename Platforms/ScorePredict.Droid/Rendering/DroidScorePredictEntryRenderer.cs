using System;
using Xamarin.Forms.Platform.Android;
using ScorePredict.Droid;
using Xamarin.Forms;
using ScorePredict.Core.Controls;

[assembly: ExportRenderer(typeof(ScorePredictEntry), typeof(DroidScorePredictEntryRenderer))]

namespace ScorePredict.Droid
{
    public class DroidScorePredictEntryRenderer : EntryRenderer
    {

    }
}

