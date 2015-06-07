using CoreGraphics;
using System.Linq;
using ScorePredict.Core.Controls;
using ScorePredict.Touch.Rendering;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(ScorePredictListView), typeof(TouchScorePredictListViewRenderer))]
namespace ScorePredict.Touch.Rendering
{
    public class TouchScorePredictListViewRenderer : ListViewRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<ListView> e)
        {
            base.OnElementChanged(e);
            if (e.OldElement == null)
            {
                Control.TableFooterView = new UIView(CGRect.Empty);
            }
        }
    }
}