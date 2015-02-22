using System;
using System.Reflection;
using CoreGraphics;
using ScorePredict.Touch.Rendering;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(TabbedPage), typeof(TouchScorePredictTabbedRenderer))]
namespace ScorePredict.Touch.Rendering
{
    public class TouchScorePredictTabbedRenderer : TabbedRenderer
    {
        public TouchScorePredictTabbedRenderer()
        {
            
        }

        protected override void OnElementChanged(VisualElementChangedEventArgs e)
        {
            base.OnElementChanged(e);
            if (e.OldElement == null)
            {
                MoreNavigationController.ViewControllers[0].Title = "Other Options";
                MoreNavigationController.Delegate = new CustomNavigationControllerDelegate();

                var vc = MoreNavigationController.ViewControllers[0];
                var tableView = (UITableView)vc.View;
                tableView.TableFooterView = new UIView(CGRect.Empty);
                tableView.BackgroundColor = UIColor.FromRGB(119, 183, 57);
            }
        }
    }

    public class CustomNavigationControllerDelegate : UINavigationControllerDelegate
    {
        // check willshow (better)
        public override void WillShowViewController(UINavigationController navigationController, UIViewController viewController, bool animated)
        {
            /*navigationController.NavigationBar.TintColor = UIColor.FromRGB(252, 210, 60);
            navigationController.NavigationBar.BarTintColor = UIColor.FromRGB(0x3c, 0x85, 0x13);
            
            navigationController.NavigationBar.TopItem.RightBarButtonItem = null;
            navigationController.NavigationBar.TopItem.Title = "More Options";*/

            var tableView = viewController.View as UITableView;
            if (tableView != null)
            {
                tableView.SeparatorInset = UIEdgeInsets.Zero;
                foreach (var cell in tableView.VisibleCells)
                {
                    cell.BackgroundColor = UIColor.FromRGB(119, 183, 57);
                    cell.TextLabel.TextColor = UIColor.White;
                    cell.Accessory = UITableViewCellAccessory.None;
                    cell.SeparatorInset = UIEdgeInsets.Zero;
                }
            }
        }
    }
}