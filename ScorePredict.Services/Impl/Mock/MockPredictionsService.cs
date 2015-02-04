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
                    AwayPredictedScore = 12, AwayTeam = "Lions", AwayTeamScore = 15, GameDay = "Mon", GameState = GameState.InProgress, GameTime = "8:10pm",
                    HomePredictedScore = 10, HomeTeam = "Cardinals", HomeTeamScore = 7, PointsAwarded = 45
                },
                new Prediction()
                {
                    AwayPredictedScore = 12, AwayTeam = "Patriots", AwayTeamScore = 15, GameDay = "Mon", GameState = GameState.Final, GameTime = "8:10pm",
                    HomePredictedScore = 10, HomeTeam = "Seahawks", HomeTeamScore = 7, PointsAwarded = 0
                },
                new Prediction()
                {
                    AwayPredictedScore = 12, AwayTeam = "Jets", AwayTeamScore = 15, GameDay = "Mon", GameState = GameState.Pregame, GameTime = "8:10pm",
                    HomePredictedScore = 10, HomeTeam = "Giants", HomeTeamScore = 7, PointsAwarded = 26
                },
                new Prediction()
                {
                    AwayPredictedScore = 12, AwayTeam = "Bills", AwayTeamScore = 15, GameDay = "Mon", GameState = GameState.Final, GameTime = "8:10pm",
                    HomePredictedScore = 10, HomeTeam = "Dolphins", HomeTeamScore = 7, PointsAwarded = 10
                },
                new Prediction()
                {
                    AwayPredictedScore = 12, AwayTeam = "Lions", AwayTeamScore = 15, GameDay = "Mon", GameState = GameState.InProgress, GameTime = "8:10pm",
                    HomePredictedScore = 10, HomeTeam = "Cardinals", HomeTeamScore = 7, PointsAwarded = 45
                },
                new Prediction()
                {
                    AwayPredictedScore = 12, AwayTeam = "Patriots", AwayTeamScore = 15, GameDay = "Mon", GameState = GameState.Final, GameTime = "8:10pm",
                    HomePredictedScore = 10, HomeTeam = "Seahawks", HomeTeamScore = 7, PointsAwarded = 0
                },
                new Prediction()
                {
                    AwayPredictedScore = 12, AwayTeam = "Jets", AwayTeamScore = 15, GameDay = "Mon", GameState = GameState.Pregame, GameTime = "8:10pm",
                    HomePredictedScore = 10, HomeTeam = "Giants", HomeTeamScore = 7, PointsAwarded = 26
                },
                new Prediction()
                {
                    AwayPredictedScore = 12, AwayTeam = "Bills", AwayTeamScore = 15, GameDay = "Mon", GameState = GameState.Pregame, GameTime = "8:10pm",
                    HomePredictedScore = 10, HomeTeam = "Dolphins", HomeTeamScore = 7, PointsAwarded = 10
                },
            };
        }
    }
}
