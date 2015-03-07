
using System.Collections.Generic;
using System.Threading.Tasks;
using ScorePredict.Common.Models;

namespace ScorePredict.Services.Contracts
{
    public interface IRankingService
    {
        Task<IList<RankingModel>> GetCurrentWeekRankings();
    }
}