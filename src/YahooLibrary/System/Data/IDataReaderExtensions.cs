using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace System.Data
{
    internal static class IDataReaderExtensions
    {
        public static Nullable<T> GetNullableValue<T>(this IDataReader reader, int columnIndex) where T : struct
        {
            if (reader.IsDBNull(columnIndex))
            {
                return default(Nullable<T>);
            }

            return (T)reader.GetValue(columnIndex);
        }

        public static T GetValue<T>(this IDataReader reader, int columnIndex) where T : class
        {
            if (reader.IsDBNull(columnIndex))
            {
                return null;
            }

            return (T)reader.GetValue(columnIndex);
        }

        public static IEnumerable<T> ToObjects<T>(this IDataReader reader, Func<IDataReader, T> converter) where T : class
        {
            var list = new List<T>();

            while (reader.Read())
            {
                var o = converter(reader);
                list.Add(o);
            }

            return list;
        }

        public static T ToObject<T>(this IDataReader reader, Func<IDataReader, T> converter) where T : class
        {
            var enumerator = reader.ToObjects<T>(converter).GetEnumerator();

            if (enumerator.MoveNext())
            {
                return enumerator.Current;
            }

            return default(T);
        }
    }
}
