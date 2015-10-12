using System.ComponentModel;
using Acr.UserDialogs;
using ScorePredict.Core.Controls;
using ScorePredict.Droid.Rendering;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(ContentLoader), typeof(ContentLoaderRenderer))]
namespace ScorePredict.Droid.Rendering
{
    public class ContentLoaderRenderer : ViewRenderer
    {
        private string _loaderMessage;

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            var loader = (ContentLoader) sender;
            if (e.PropertyName == "Message")
                _loaderMessage = loader.Message;

            if (e.PropertyName == "IsVisible" && !string.IsNullOrEmpty(_loaderMessage))
            {
                if (loader.IsVisible)
                {
                    UserDialogs.Instance.ShowLoading(_loaderMessage);
                }
                else
                {
                    UserDialogs.Instance.HideLoading();
                }
            }
        }
    }
}