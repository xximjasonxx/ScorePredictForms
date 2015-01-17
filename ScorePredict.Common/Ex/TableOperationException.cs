using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScorePredict.Data.Ex
{
    public class TableOperationException : Exception
    {
        public string OperationType { get; private set; }

        public TableOperationException(string operationType, Exception ex)
            : base("Table Operation Failed", ex)
        {
            
        }
    }
}
