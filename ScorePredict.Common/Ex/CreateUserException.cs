using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScorePredict.Data.Ex
{
    public class CreateUserException : Exception
    {
        public CreateUserException(string errorMessage)
            : base(errorMessage)
        {
        }
    }
}
