
namespace ScorePredict.Common.Data
{
    public class Prediction
    {
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

        public string PointsAwardedDisplay
        {
            get
            {
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
    }
}
