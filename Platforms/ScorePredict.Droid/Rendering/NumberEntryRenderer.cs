using Android.Text;
using ScorePredict.Core.Controls;
using ScorePredict.Droid.Rendering;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(NumberEntry), typeof(NumberEntryRenderer))]
namespace ScorePredict.Droid.Rendering
{
    public class NumberEntryRenderer : EntryRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);

            if (Control != null)
            {
                Control.InputType = InputTypes.ClassNumber;
            }
        }
    }
}