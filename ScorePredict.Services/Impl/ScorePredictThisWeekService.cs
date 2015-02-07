using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ScorePredict.Common.Data;
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
                //{"weekForDate", DateTime.Now.ToString("d")}
                {"weekForDate", "10/13/2014"}
            };

            var result = (await Client.GetApiAsync("weekdatafor", parameters)).AsDictionary();
            return new WeekSummary()
            {
                Points = result[0]["Points"].AsInt(),
                Ranking = result[0]["Ranking"].AsInt(),
                UserCount = result[0]["UserCount"].AsInt(),
                TotalPredictions = result[0]["TotalPredictions"].AsInt(),
                UserId = result[0]["UserId"],
                WeekId = result[0]["WeekId"]
            };
        }
    }
}
