using System;
using System.Reflection;
using CoreGraphics;
using Foundation;
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
                MoreNavigationController.Delegate = new CustomNavigationControllerDelegate();
                Delegate = new CustomTabBarControllerDelegate();

                var vc = MoreNavigationController.ViewControllers[0];
                var tableView = (UITableView)vc.View;
                tableView.TableFooterView = new UIView(CGRect.Empty);
                tableView.BackgroundColor = UIColor.FromRGB(119, 183, 57);
            }
        }
    }

    public class CustomTabBarControllerDelegate : UITabBarControllerDelegate
    {
        public override void WillChangeValue(string forKey)
        {
            base.WillChangeValue(forKey);
        }

        public override void WillChange(NSKeyValueChange changeKind, NSIndexSet indexes, NSString forKey)
        {
            base.WillChange(changeKind, indexes, forKey);
        }

        public override void WillChange(NSString forKey, NSKeyValueSetMutationKind mutationKind, NSSet objects)
        {
            base.WillChange(forKey, mutationKind, objects);
        }

        public override bool ShouldSelectViewController(UITabBarController tabBarController, UIViewController viewController)
        {
            //var tableView = viewController.View as UITableView;
            var navController = viewController as UINavigationController;
            if (navController == null)
            {
                tabBarController.NavigationController.NavigationBarHidden = false;
            }
            else
            {
                tabBarController.NavigationController.NavigationBarHidden = true;
            }

            return true;
        }
    }

    public class CustomNavigationControllerDelegate : UINavigationControllerDelegate
    {
        // check willshow (better)
        public override void WillShowViewController(UINavigationController navigationController, UIViewController viewController, bool animated)
        {
            var tableView = viewController.View as UITableView;
            if (tableView != null)
            {
                //navigationController.NavigationBar.Hidden = true;
                /*navigationController.TabBarController.NavigationController
                    .ViewControllers[0].Title = "More Options";*/

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

        public override void DidShowViewController(UINavigationController navigationController, UIViewController viewController, bool animated)
        {
            var tableView = viewController.View as UITableView;
            if (tableView == null)
            {
                if (!string.IsNullOrEmpty(viewController.Title))
                {
                    navigationController.TabBarController.NavigationController
                        .ViewControllers[0].Title = viewController.Title;
                }

                if (viewController.ToolbarItems != null && viewController.ToolbarItems.Length > 0)
                {
                    navigationController.TabBarController.NavigationController
                        .SetToolbarItems(viewController.ToolbarItems, true);
                }
            }
        }
    }
}