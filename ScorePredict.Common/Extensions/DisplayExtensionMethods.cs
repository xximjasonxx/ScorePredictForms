using System;
using System.Linq;

namespace ScorePredict.Common.Extensions
{
    public static class DisplayExtensionMethods
    {
        public static string WithOrdinalSuffix(this int number)
        {
            var ones = number%10;
            var tens = Math.Floor((decimal)number/10)%10;

            if (tens == 1)
                return string.Format("{0}th", number);

            switch (ones)
            {
                case 1: return string.Format("{0}st", number);
                case 2: return string.Format("{0}nd", number);
                case 3: return string.Format("{0}rd", number);
                default: return string.Format("{0}th", number);
            }
        }

        public static string AsTeamName(this string fullTeamName)
        {
            if (string.IsNullOrEmpty(fullTeamName))
                throw new ArgumentException("Not a valid full team name");

            var parts = fullTeamName.Split(' ');
            return parts.Last();
        }
    }
}
