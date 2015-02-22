using ScorePredict.Core.Controls;
using ScorePredict.Touch.Rendering;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

//[assembly: ExportRenderer(typeof(ScorePredictParentNavigationPage), typeof(TouchScorePredictParentNavigationRenderer))]
namespace ScorePredict.Touch.Rendering
{
    public class TouchScorePredictParentNavigationRenderer : NavigationRenderer
    {
        protected override void OnElementChanged(VisualElementChangedEventArgs e)
        {
            base.OnElementChanged(e);

            if (e.OldElement == null)
            {
                //NavigationBar.Hidden = true;
            }
        }
    }
}