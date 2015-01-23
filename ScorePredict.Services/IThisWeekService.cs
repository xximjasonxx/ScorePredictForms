using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ScorePredict.Common.Data;

namespace ScorePredict.Services
{
    public interface IThisWeekService
    {
        Task<WeekSummary> GetCurrentWeekSummaryAsync();
    }
}
