using System.ComponentModel;
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

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            var contentLoader = sender as ContentLoader;
            if (sender != null && e.PropertyName == "Message")
            {
                var view = contentLoader.Content;
                if (view != null && view.FindByName<Label>("messageLabel") != null && !string.IsNullOrEmpty(contentLoader.Message))
                {
                    view.FindByName<Label>("messageLabel").Text = contentLoader.Message;
                }
            }
        }
    }
}
