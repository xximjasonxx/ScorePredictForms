using System;

namespace ScorePredict.Data
{
    public class LoginException : Exception
    {
        public LoginException(string errorMessage)
            : base(errorMessage)
        {
        }
    }
}

