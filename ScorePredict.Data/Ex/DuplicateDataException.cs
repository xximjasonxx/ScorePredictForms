using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScorePredict.Data.Ex
{
    public class DuplicateDataException : Exception
    {
        public string Field { get; private set; }

        public DuplicateDataException(string fieldName, Exception ex) : base("Duplicate Data Exists", ex)
        {
            Field = fieldName;
        }
    }
}
