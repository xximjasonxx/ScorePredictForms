using System;
using System.Globalization;
using Xamarin.Forms;

namespace ScorePredict.Core.Converters
{
    public class InvertedBooleanValueConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var boolValue = !(bool) value;
            return boolValue;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
