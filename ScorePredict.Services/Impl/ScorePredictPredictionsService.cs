using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ScorePredict.Common.Data;
using ScorePredict.Common.Extensions;
using ScorePredict.Services.Contracts;
using ScorePredict.Services.Extensions;

namespace ScorePredict.Services.Impl
{
    public class ScorePredictPredictionsService : IPredictionsService
    {
        public IClient Client { get; private set; }

        public ScorePredictPredictionsService(IClient client)
        {
            Client = client;
        }

        public async Task<IList<Prediction>> GetCurrentWeekPredictions()
        {
            var parameters = new Dictionary<string, string>()
            {
                //{"weekForDate", DateTime.Now.ToString("d")}
                {"weekForDate", "10/03/2014"}
            };

            var result = (await Client.GetApiAsync("predictions_for", parameters)).AsDictionary();
            return result.Select(x => new Prediction()
            {
               GameDay = x["gameDay"],
               GameTime = x["gameTime"],
               GameState = x["gameState"].AsGameStateEnumeration(),
               AwayTeam = x["awayTeam"],
               HomeTeam = x["homeTeam"],
               AwayTeamScore = x["awayTeamScore"].AsInt(),
               HomeTeamScore = x["homeTeamScore"].AsInt(),
               AwayPredictedScore = x["awayPredictedScore"].AsInt(),
               HomePredictedScore = x["homePredictedScore"].AsInt(),
               PointsAwarded = x["pointsAwarded"].AsInt()
            }).ToList();
        }
    }
}
