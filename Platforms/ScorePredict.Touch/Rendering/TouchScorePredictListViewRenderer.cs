using CoreGraphics;
using System.Linq;
using ScorePredict.Core.Controls;
using ScorePredict.Touch.Rendering;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(ScorePredictListView), typeof(TouchScorePredictListViewRenderer))]
[assembly: ExportRenderer(typeof(ViewCell), typeof(TouchScorePredictionViewCellRenderer))]
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

    public class TouchScorePredictionViewCellRenderer : ViewCellRenderer
    {
        public override UITableViewCell GetCell(Cell item, UITableViewCell reusableCell, UITableView tv)
        {
            var cell = base.GetCell(item, reusableCell, tv);

            UIView view = new UIView(new CGRect(0, 0, cell.Frame.Width, cell.Frame.Height));
            view.BackgroundColor = UIColor.Clear;
            cell.SelectedBackgroundView = view;

            return cell;
        }
    }
}