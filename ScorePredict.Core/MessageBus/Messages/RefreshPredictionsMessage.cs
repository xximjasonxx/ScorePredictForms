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

        public RefreshPredictionsMessage(int predictionId, int awayScore, int homeScore)
        {
            PredictionId = predictionId;
            AwayTeamScore = awayScore;
            HomeTeamScore = homeScore;
        }
    }
}
