using System.ComponentModel;
using Acr.XamForms.UserDialogs;
using Acr.XamForms.UserDialogs.Droid;
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
        private UserDialogService _dialogService;

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            var loader = (ContentLoader) sender;
            if (e.PropertyName == "Message")
                _loaderMessage = loader.Message;

            if (e.PropertyName == "IsVisible" && !string.IsNullOrEmpty(_loaderMessage))
            {
                if (loader.IsVisible)
                {
                    _dialogService = new UserDialogService();
                    _dialogService.ShowLoading(_loaderMessage);
                }
                else
                {
                    _dialogService.HideLoading();
                }
            }
        }
    }
}