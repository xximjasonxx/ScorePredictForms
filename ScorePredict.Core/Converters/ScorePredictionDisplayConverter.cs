using System;
using System.Globalization;
using Xamarin.Forms;

namespace ScorePredict.Core.Converters
{
    public class IntDisplayValueConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            int intVal = (int) value;
            if (intVal >= 0)
                return intVal.ToString();

            return string.Empty;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
