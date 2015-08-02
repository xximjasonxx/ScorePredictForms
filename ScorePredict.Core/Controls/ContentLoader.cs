using Xamarin.Forms;

namespace ScorePredict.Core.Controls
{
    public class ContentLoader : ContentView
    {
        public static BindableProperty MessageProperty =
            BindableProperty.Create<ContentLoader, string>(x => x.Message, null, BindingMode.OneWay,
                null, MessagePropertyChanged);

        private static void MessagePropertyChanged(BindableObject bindable, string oldValue, string newValue)
        {
            var content = ((ContentLoader) bindable).Content;
            if (content != null)
            {
                content.FindByName<Label>("messageLabel").Text = newValue;
            }
        }

        public string Message
        {
            get { return GetValue(MessageProperty) as string; }
            set { SetValue(MessageProperty, value); }
        }
    }
}
