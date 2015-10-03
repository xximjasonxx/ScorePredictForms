using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScorePredict.Common.Data
{
    public class PredictionResult
    {
        public int GameId { get; set; }
        public string WeekId { get; set; }
        public int AwayPredictedScore { get; set; }
        public int HomePredictedScore { get; set; }
        public int PredictionId { get; set; }
    }
}
