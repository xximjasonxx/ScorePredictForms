using System.Windows.Media;
using ScorePredict.Core;
using ScorePredict.Core.Controls;
using ScorePredict.Phone.Rendering;
using Xamarin.Forms;
using Xamarin.Forms.Platform.WinPhone;
using Xamarin.Forms.Xaml;

[assembly: ExportRenderer(typeof(ContentLoader), typeof(ContentLoaderRenderer))]
namespace ScorePredict.Phone.Rendering
{
    public class ContentLoaderRenderer : ViewRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<View> e)
        {
            base.OnElementChanged(e);

            if (e.OldElement == null)
            {
                var view = (ContentLoader) e.NewElement;
                view.LoadFromXaml(typeof (ContentLoaderView));
            }
        }
    }
}
