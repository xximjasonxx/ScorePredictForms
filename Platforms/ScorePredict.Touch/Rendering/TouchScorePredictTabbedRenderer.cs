using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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

            MoreNavigationController.NavigationBar.Hidden = true;
            UITableView tableView = (UITableView)MoreNavigationController.ViewControllers[0].View;

            tableView.BackgroundColor = UIColor.FromRGB(119, 183, 57);
        }
    }
}