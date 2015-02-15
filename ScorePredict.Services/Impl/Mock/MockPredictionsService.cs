using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ScorePredict.Common;
using ScorePredict.Common.Data;
using ScorePredict.Common.Models;

namespace ScorePredict.Services.Impl.Mock
{
    public class MockPredictionService : IPredictionService
    {
        public async Task<IList<Prediction>> GetCurrentWeekPredictions()
        {
            return new List<Prediction>()
            {
                new Prediction()
                {
                    AwayPredictedScore = 12, AwayTeam = "Lions", AwayTeamScore = 15, GameDay = "Mon", GameState = GameState.InProgress, GameTime = "8:10pm",
                    HomePredictedScore = 10, HomeTeam = "Cardinals", HomeTeamScore = 7, PointsAwarded = 45, GameId = 1234, WeekId = "abcd"
                },
                new Prediction()
                {
                    AwayPredictedScore = 12, AwayTeam = "Patriots", AwayTeamScore = 15, GameDay = "Mon", GameState = GameState.Final, GameTime = "8:10pm",
                    HomePredictedScore = 10, HomeTeam = "Seahawks", HomeTeamScore = 7, PointsAwarded = 0, GameId = 1234, WeekId = "abcd"
                },
                new Prediction()
                {
                    AwayPredictedScore = 12, AwayTeam = "Jets", AwayTeamScore = 15, GameDay = "Mon", GameState = GameState.Pregame, GameTime = "8:10pm",
                    HomePredictedScore = 10, HomeTeam = "Giants", HomeTeamScore = 7, PointsAwarded = 26, GameId = 1234, WeekId = "abcd"
                },
                new Prediction()
                {
                    AwayPredictedScore = 12, AwayTeam = "Bills", AwayTeamScore = 15, GameDay = "Mon", GameState = GameState.Final, GameTime = "8:10pm",
                    HomePredictedScore = 10, HomeTeam = "Dolphins", HomeTeamScore = 7, PointsAwarded = 10, GameId = 1234, WeekId = "abcd"
                },
                new Prediction()
                {
                    AwayPredictedScore = 12, AwayTeam = "Lions", AwayTeamScore = 15, GameDay = "Mon", GameState = GameState.InProgress, GameTime = "8:10pm",
                    HomePredictedScore = 10, HomeTeam = "Cardinals", HomeTeamScore = 7, PointsAwarded = 45, GameId = 1234, WeekId = "abcd"
                },
                new Prediction()
                {
                    AwayPredictedScore = 12, AwayTeam = "Patriots", AwayTeamScore = 15, GameDay = "Mon", GameState = GameState.Final, GameTime = "8:10pm",
                    HomePredictedScore = 10, HomeTeam = "Seahawks", HomeTeamScore = 7, PointsAwarded = 0, GameId = 1234, WeekId = "abcd"
                },
                new Prediction()
                {
                    AwayPredictedScore = 12, AwayTeam = "Jets", AwayTeamScore = 15, GameDay = "Mon", GameState = GameState.Pregame, GameTime = "8:10pm",
                    HomePredictedScore = 10, HomeTeam = "Giants", HomeTeamScore = 7, PointsAwarded = 26, GameId = 1234, WeekId = "abcd"
                },
                new Prediction()
                {
                    AwayPredictedScore = 12, AwayTeam = "Bills", AwayTeamScore = 15, GameDay = "Mon", GameState = GameState.Pregame, GameTime = "8:10pm",
                    HomePredictedScore = 10, HomeTeam = "Dolphins", HomeTeamScore = 7, PointsAwarded = 10, GameId = 1234, WeekId = "abcd"
                },
            };
        }

        public async Task<Prediction> SavePredictionAsync(SavePredictionModel savePredictionModel)
        {
            return new Prediction();
        }

        public Task<IList<int>> GetPredictionYearsAsync()
        {
            throw new NotImplementedException();
        }
    }
}
