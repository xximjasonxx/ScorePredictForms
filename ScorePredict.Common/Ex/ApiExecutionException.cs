using System;

namespace ScorePredict.Common.Ex
{
    public class ApiExecutionException : Exception
    {
        public string ApiName { get; private set; }

        public ApiExecutionException(string apiName, Exception ex)
            : base(string.Format("Execuitn Api {0} failed", apiName), ex)
        {
            ApiName = apiName;
        }
    }
}
