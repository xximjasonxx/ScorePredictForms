using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScorePredict.Data.Ex
{
    public class CreateUserException : Exception
    {
        public string ErrorMessage { get; private set; }

        public CreateUserException(string errorMessage)
        {
            ErrorMessage = errorMessage;
        }
    }
}
