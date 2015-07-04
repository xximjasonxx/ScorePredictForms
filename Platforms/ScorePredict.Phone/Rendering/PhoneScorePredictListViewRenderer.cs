using ScorePredict.Core.Controls;
using ScorePredict.Phone.Rendering;
using Xamarin.Forms;
using Xamarin.Forms.Platform.WinPhone;

[assembly: ExportRenderer(typeof(ScorePredictListView), typeof(PhoneScorePredictListViewRenderer))]
namespace ScorePredict.Phone.Rendering
{
    public class PhoneScorePredictListViewRenderer : ListViewRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<ListView> e)
        {
            base.OnElementChanged(e);

            if (e.OldElement == null)
            {
                
            }
        }
    }
}
