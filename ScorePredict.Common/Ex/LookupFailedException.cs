using System;

namespace ScorePredict.Common.Ex
{
    public class LookupFailedException : Exception
    {
        public string TableName { get; private set; }
        public string Key { get; private set; }

        public LookupFailedException(string tableName, string key, Exception ex)
            : base(string.Format("Lookup of Key {0} failed in table {1}", key, tableName), ex)
        {
            TableName = tableName;
            Key = key;
        }
    }
}
