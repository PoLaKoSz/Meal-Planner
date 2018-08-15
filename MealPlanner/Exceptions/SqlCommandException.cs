using System;
using System.Data.Common;
using System.Runtime.Serialization;

namespace MealPlanner.Exceptions
{
    public class SqlCommandException : DbException
    {
        public SqlCommandException()
        {
        }

        public SqlCommandException(string message) : base(message)
        {
        }

        public SqlCommandException(string message, Exception innerException) : base(message, innerException)
        {
        }

        public SqlCommandException(string message, int errorCode) : base(message, errorCode)
        {
        }

        public SqlCommandException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
