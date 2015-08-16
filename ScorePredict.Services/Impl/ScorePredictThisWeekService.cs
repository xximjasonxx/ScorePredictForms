using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ScorePredict.Common.Data;
using ScorePredict.Common.Ex;
using ScorePredict.Common.Extensions;
using ScorePredict.Services.Contracts;
using ScorePredict.Services.Extensions;

namespace ScorePredict.Services.Impl
{
    public class ScorePredictThisWeekService : IThisWeekService
    {
        public IClient Client { get; private set; }

        public ScorePredictThisWeekService(IClient client)
        {
            Client = client;
        }

        public async Task<WeekSummary> GetCurrentWeekSummaryAsync()
        {
            var parameters = new Dictionary<string, string>()
            {
               {"weekForDate", DateTime.Now.ToString("d")}
               // {"weekForDate", "9/5/2014"}
            };

            try
            {
                var result = (await Client.GetApiAsync("weekdatafor", parameters)).AsDictionary();
                return new WeekSummary()
                {
                    Points = result[0]["totalPoints"].AsInt(),
                    Ranking = result[3]["yourRank"].AsInt(),
                    TotalPredictions = result[1]["totalPredictions"].AsInt(),
                    UserCount = result[3]["outOf"].AsInt(),
                    UserId = result[0]["userId"],
                    WeekId = result[0]["weekId"],
                    WeekNumber = result[2]["weekNumber"].AsInt(),
                    Year = result[2]["year"].AsInt(),
                    GamesCount = result[4]["gameCount"].AsInt()
                };
            }
            catch (NotFoundException)
            {
                return new WeekSummary()
                {
                    Points = 0,
                    Ranking = 0,
                    TotalPredictions = 0,
                    UserCount = 0,
                    UserId = string.Empty,
                    WeekId = String.Empty,
                    WeekNumber = 0,
                    Year = 0,
                    GamesCount = 0
                };
            }
        }
    }
}
