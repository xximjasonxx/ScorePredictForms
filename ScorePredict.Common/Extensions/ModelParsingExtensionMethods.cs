using System.Collections.Generic;
using ScorePredict.Common.Data;

namespace ScorePredict.Common.Extensions
{
    public static class ModelParsingExtensionMethods
    {
        public static PredictionResult AsPredictionResult(this IDictionary<string, string> source)
        {
            return new PredictionResult()
            {
                GameId = source["gameId"].AsInt(),
                WeekId = source["weekId"],
                AwayPredictedScore = source["awayTeamScore"].AsInt(0),
                HomePredictedScore = source["homeTeamScore"].AsInt(0),
                PredictionId = source["id"].AsInt()
            };
        }
    }
}
