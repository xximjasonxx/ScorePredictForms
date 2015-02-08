using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScorePredict.Common.Models
{
    public class SavePredictionModel
    {
        public int GameId { get; set; }
        public int AwayPrediction { get; set; }
        public int HomePrediction { get; set; }
        public string WeekId { get; set; }
    }
}
