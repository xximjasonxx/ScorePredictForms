using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ScorePredict.Common.Ex;
using ScorePredict.Common.Extensions;
using ScorePredict.Common.Models;
using ScorePredict.Services.Contracts;
using ScorePredict.Services.Extensions;

namespace ScorePredict.Services.Impl
{
    public class ScorePredictRankingService : IRankingService
    {
        private readonly IClient _client;

        public ScorePredictRankingService(IClient client)
        {
            _client = client;
        }

        public async Task<IList<RankingModel>> GetCurrentWeekRankings()
        {
            try
            {
                var parameters = new Dictionary<string, string>()
                {
                    {"weekOf", DateTime.Now.ToString("d")}
                    //{"weekOf", "9/5/2014"}
                };

                var dictionary = (await _client.GetApiAsync("rankings", parameters)).AsDictionary();
                return dictionary.Select(x => new RankingModel()
                {
                    Rank = x["rank"].AsInt(),
                    UserId = x["userId"],
                    Username = x["userDisplay"],
                    Points = x["points"].AsInt()
                }).ToList();
            }
            catch (NotFoundException)
            {
                return new List<RankingModel>();
            }
        }
    }
}
