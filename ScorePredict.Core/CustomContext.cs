using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ScorePredict.Common.Data;

namespace ScorePredict.Core
{
    public class CustomContext
    {
        private static CustomContext _currentInstance;

        public static CustomContext Current { get { return _currentInstance ?? new CustomContext(); } }

        private CustomContext()
        {
            // do nothing - singleton
        }

        public Prediction LastPrediction { get; set; }
    }
}
