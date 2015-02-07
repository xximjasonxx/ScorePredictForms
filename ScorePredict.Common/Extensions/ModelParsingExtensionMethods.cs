using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ScorePredict.Common.Data;

namespace ScorePredict.Common.Extensions
{
    public static class ModelParsingExtensionMethods
    {
        public static Prediction AsPrediction(this IDictionary<string, string> source)
        {
            return new Prediction();
        }
    }
}
