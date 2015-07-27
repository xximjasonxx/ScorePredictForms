using System.Windows.Input;
using Microsoft.Phone.Controls;
using ScorePredict.Core.Controls;
using ScorePredict.Phone.Rendering;
using Xamarin.Forms;
using Xamarin.Forms.Platform.WinPhone;

[assembly: ExportRenderer(typeof(NumberEntry), typeof(NumbersEntryRenderer))]
namespace ScorePredict.Phone.Rendering
{
    public class NumbersEntryRenderer : EntryRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            if (e.OldElement == null)
            {
                var control = (PhoneTextBox) Control.Children[0];
                InputScope inputScope = new InputScope();
                InputScopeName inputScopeName = new InputScopeName();

                inputScopeName.NameValue = InputScopeNameValue.TelephoneNumber;
                inputScope.Names.Add(inputScopeName);
                control.InputScope = inputScope;
            }
        }
    }
}
