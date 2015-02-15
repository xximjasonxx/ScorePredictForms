using System;

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

        public string PointsAwardedDisplay
        {
            get
            {
                if (PointsAwarded == 1)
                    return "1pt";

                return String.Format("{0}pts", PointsAwarded);
            }
        }
    }
}
