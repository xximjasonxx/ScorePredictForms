
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using ScorePredict.Common.Data;
using ScorePredict.Common.Models;
using ScorePredict.Common.Utility;

namespace ScorePredict.Services
{
    public interface IPredictionService
    {
        Task<IList<Prediction>> GetCurrentWeekPredictions();
        Task<Prediction> SavePredictionAsync(SavePredictionModel savePredictionModel);
        Task<IList<int>> GetPredictionYearsAsync();
        Task<IList<PredictionViewModel>> GetPredictionsForYearAsync(int year);
    }
}