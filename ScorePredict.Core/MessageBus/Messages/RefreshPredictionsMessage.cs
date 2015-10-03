using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScorePredict.Core.MessageBus.Messages
{
    public class RefreshPredictionsMessage : IMessage
    {
        public int PredictionId { get; private set; }
        public int AwayTeamScore { get; private set; }
        public int HomeTeamScore { get; private set; }
        public string HomeTeam { get; set; }
        public string AwayTeam { get; set; }

        public RefreshPredictionsMessage(int predictionId, string homeTeam, string awayTeam, int awayScore, int homeScore)
        {
            PredictionId = predictionId;
            HomeTeam = homeTeam;
            AwayTeam = awayTeam;
            AwayTeamScore = awayScore;
            HomeTeamScore = homeScore;
        }
    }
}
