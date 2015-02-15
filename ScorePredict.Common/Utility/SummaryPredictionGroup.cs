using System.Collections.Generic;
using System.Linq;
using ScorePredict.Common.Models;

namespace ScorePredict.Common.Utility
{
    public class SummaryPredictionGroup : List<PredictionViewModel>
    {
        public string Key { get; private set; }
        public int TotalPoints { get; private set; }

        public string TotalPointsDisplay
        {
            get
            {
                if (TotalPoints == 1)
                    return "1pt";

                return string.Format("{0}pts", TotalPoints);
            }
        }

        public SummaryPredictionGroup(string key, IList<PredictionViewModel> predictions) : base(predictions)
        {
            Key = key;
            TotalPoints = predictions.Sum(p => p.PointsAwarded);
        }
    }
}
