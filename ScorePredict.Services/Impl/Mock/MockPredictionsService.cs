using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ScorePredict.Common;
using ScorePredict.Common.Data;

namespace ScorePredict.Services.Impl.Mock
{
    public class MockPredictionsService : IPredictionsService
    {
        public async Task<IList<Prediction>> GetCurrentWeekPredictions()
        {
            return new List<Prediction>()
            {
                new Prediction()
                {
                    AwayPredictedScore = 12, AwayTeam = "DET", AwayTeamScore = 15, GameDay = "Mon", GameState = GameState.Final, GameTime = "8:10pm",
                    HomePredictedScore = 10, HomeTeam = "ARI", HomeTeamScore = 7, PointsAwarded = 45
                },
                new Prediction()
                {
                    AwayPredictedScore = 12, AwayTeam = "NE", AwayTeamScore = 15, GameDay = "Mon", GameState = GameState.Final, GameTime = "8:10pm",
                    HomePredictedScore = 10, HomeTeam = "SEA", HomeTeamScore = 7, PointsAwarded = 0
                },
                new Prediction()
                {
                    AwayPredictedScore = 12, AwayTeam = "NYJ", AwayTeamScore = 15, GameDay = "Mon", GameState = GameState.Final, GameTime = "8:10pm",
                    HomePredictedScore = 10, HomeTeam = "NYG", HomeTeamScore = 7, PointsAwarded = 26
                },
                new Prediction()
                {
                    AwayPredictedScore = 12, AwayTeam = "BUF", AwayTeamScore = 15, GameDay = "Mon", GameState = GameState.Final, GameTime = "8:10pm",
                    HomePredictedScore = 10, HomeTeam = "MIA", HomeTeamScore = 7, PointsAwarded = 10
                },
            };
        }
    }
}
