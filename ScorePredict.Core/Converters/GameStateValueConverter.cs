using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ScorePredict.Common;
using Xamarin.Forms;

namespace ScorePredict.Core.Converters
{
    public class GameStateValueConverter : IValueConverter
    {
        private const string PregameDisplay = "Pregame";
        private const string InProgressDisplay = "In Progress";
        private const string FinalDisplay = "Final";

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            GameState state = (GameState) value;
            if (state == GameState.Pregame)
                return PregameDisplay;

            if (state == GameState.Final)
                return FinalDisplay;

            return InProgressDisplay;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
