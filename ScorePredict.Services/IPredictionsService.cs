
using System.Collections.Generic;
using System.Threading.Tasks;
using ScorePredict.Common.Data;
using ScorePredict.Common.Models;

namespace ScorePredict.Services
{
    public interface IPredictionService
    {
        Task<IList<Prediction>> GetCurrentWeekPredictions();
        Task<PredictionResult> SavePredictionAsync(SavePredictionModel savePredictionModel);
        Task<IList<int>> GetPredictionYearsAsync();
        Task<IList<PredictionViewModel>> GetPredictionsForYearAsync(int year);
    }
}