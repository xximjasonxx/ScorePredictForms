using System.Collections.Generic;
using ScorePredict.Common.Data;

namespace ScorePredict.Common.Utility
{
    public class PredictionGroup : List<Prediction>
    {
        public string Key { get; private set; }

        public PredictionGroup(string key, IList<Prediction> predictions) : base(predictions)
        {
            Key = key;
        }
    }
}
