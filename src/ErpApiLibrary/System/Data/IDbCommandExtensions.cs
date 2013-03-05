using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace System.Data
{
    public static class IDbCommandExtensions
    {
        public static IDataParameter AddParameterWithValue<T>(this IDbCommand dbCommand, string parameterName, T value)
        {
            var p = dbCommand.CreateParameter();
            p.ParameterName = parameterName;

            if (value != null)
            {
                p.Value = value;
            }
            else
            {
                p.Value = DBNull.Value;
            }

            dbCommand.Parameters.Add(p);

            return p;
        }
    }
}
