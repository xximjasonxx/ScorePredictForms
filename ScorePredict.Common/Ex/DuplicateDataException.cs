using System;
using System.Collections.Generic;

namespace ScorePredict.Common.Ex
{
    public class DuplicateDataException : Exception
    {
        public string TableName { get; private set; }
        public IDictionary<string, string> Parameters { get; private set; }

        public DuplicateDataException(string tableName, IDictionary<string, string> parameters, Exception ex)
            : base(string.Format("Duplicate data found in table {0}", tableName), ex)
        {
            TableName = tableName;
            Parameters = parameters;
        }
    }
}
