using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ScorePredict.Common.Data;

namespace ScorePredict.Services.Impl.Mock
{
    public class MockThisWeekService : IThisWeekService
    {
        public async Task<WeekSummary> GetCurrentWeekSummaryAsync()
        {
            return new WeekSummary()
            {
                Points = 999,
                Ranking = 1,
                TotalPredictions = 12,
                UserCount = 5,
                UserId = "MyUserId",
                WeekId = "MyWeekId",
                WeekNumber = 12,
                Year = 2015
            };
        }
    }
}
