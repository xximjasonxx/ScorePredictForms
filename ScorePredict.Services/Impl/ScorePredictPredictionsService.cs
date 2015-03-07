using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ScorePredict.Common.Data;
using ScorePredict.Common.Extensions;
using ScorePredict.Common.Models;
using ScorePredict.Services.Contracts;
using ScorePredict.Services.Extensions;

namespace ScorePredict.Services.Impl
{
    public class ScorePredictPredictionService : IPredictionService
    {
        public IList<PredictionViewModel> Predictions { get; set; }

        public IClient Client { get; private set; }

        public ScorePredictPredictionService(IClient client)
        {
            Client = client;
        }

        public async Task<IList<Prediction>> GetCurrentWeekPredictions()
        {
            var parameters = new Dictionary<string, string>()
            {
                //{"weekForDate", DateTime.Now.ToString("d")}
                {"weekForDate", "9/5/2014"}
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
               AwayPredictedScore = x["awayPredictedScore"].AsInt(-1),
               HomePredictedScore = x["homePredictedScore"].AsInt(-1),
               PointsAwarded = x["pointsAwarded"].AsInt(-1)
            }).ToList();
        }

        public async Task<Prediction> SavePredictionAsync(SavePredictionModel savePredictionModel)
        {
            var parameters = new Dictionary<string, string>
            {
                { "gameId", savePredictionModel.GameId.ToString() },
                { "weekId", savePredictionModel.WeekId },
                { "awayPredictedScore", savePredictionModel.AwayPrediction.ToString() },
                { "homePredictedScore", savePredictionModel.HomePrediction.ToString() }
            };

            var result = (await Client.UpdateTable("predictions", parameters)).AsDictionary();
            return result[0].AsPrediction();
        }

        public async Task<IList<int>> GetPredictionYearsAsync()
        {
            if (Predictions == null)
                Predictions = await GetAllPredictionsAsync();

            return Predictions.OrderByDescending(p => p.Year).Select(p => p.Year).Distinct().ToList();
        }

        public async Task<IList<PredictionViewModel>> GetPredictionsForYearAsync(int year)
        {
            if (Predictions == null)
                Predictions = await GetAllPredictionsAsync();

            return Predictions.Where(p => p.Year == year).ToList();
        }

        private async Task<IList<PredictionViewModel>> GetAllPredictionsAsync()
        {
            var result = (await Client.ReadTableAsync("predictions", new Dictionary<string, string>())).AsDictionary();
            return result.Select(x => new PredictionViewModel()
            {
                AwayTeamName = x["awayTeam"].AsTeamName(),
                HomeTeamName = x["homeTeam"].AsTeamName(),
                AwayScore = x["awayScore"].AsInt(),
                HomeScore = x["homeScore"].AsInt(),
                PointsAwarded = x["pointsAwarded"].AsInt(),
                PredictedAwayScore = x["predictedAwayScore"].AsInt(),
                PredictedHomeScore = x["predictedHomeScore"].AsInt(),
                WeekNumber = x["weekNumber"].AsInt(),
                Year = x["year"].AsInt()
            }).ToList();
        }
    }
}
