using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScorePredict.Common.Models
{
    public class PredictionViewModel
    {
        public int Year { get; set; }
        public int WeekNumber { get; set; }
        public string AwayTeamName { get; set; }
        public string HomeTeamName { get; set; }
        public int AwayScore { get; set; }
        public int HomeScore { get; set; }
        public int PredictedAwayScore { get; set; }
        public int PredictedHomeScore { get; set; }
        public int PointsAwarded { get; set; }
    }
}
