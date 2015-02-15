
using System.Linq;

namespace ScorePredict.Common.Data
{
    public class Prediction
    {
        public int GameId { get; set; }
        public string WeekId { get; set; }
        public string GameDay { get; set; }
        public string GameTime { get; set; }
        public GameState GameState { get; set; }
        public string AwayTeam { get; set; }
        public string HomeTeam { get; set; }
        public int AwayTeamScore { get; set; }
        public int HomeTeamScore { get; set; }
        public int AwayPredictedScore { get; set; }
        public int HomePredictedScore { get; set; }
        public int PointsAwarded { get; set; }

        public string HomeTeamName
        {
            get { return GetTeamName(HomeTeam); }
        }

        public string AwayTeamName
        {
            get { return GetTeamName(AwayTeam); }
        }

        public string PointsAwardedDisplay
        {
            get
            {
                if (PointsAwarded < 0)
                    return string.Empty;

                if (PointsAwarded == 1)
                    return "1 Point";

                return string.Format("{0} Points", PointsAwarded);
            }
        }

        public bool IsConcluded
        {
            get { return GameState == GameState.Final; }
        }

        public bool InPregame
        {
            get { return GameState == GameState.Pregame; }
        }

        private string GetTeamName(string fullName)
        {
            string[] parts = fullName.Split(' ');
            return parts.Last();
        }
    }
}
