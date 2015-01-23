using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScorePredict.Common.Extensions
{
    public static class ParsingExtensionMethods
    {
        public static int AsInt(this string str, int defaultValue = int.MinValue)
        {
            int intVal;
            if (!int.TryParse(str, out intVal))
                return defaultValue;

            return intVal;
            ;
        }
    }
}
