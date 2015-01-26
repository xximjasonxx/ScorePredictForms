
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using ScorePredict.Common.Data;

namespace ScorePredict.Services
{
    public interface IPredictionsService
    {
        Task<IList<Prediction>> GetCurrentWeekPredictions();
    }
}