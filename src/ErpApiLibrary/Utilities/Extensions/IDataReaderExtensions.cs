using System.Collections.Generic;

namespace System.Data
{
    /// <summary>
    /// IDataReader 的擴充方法。
    /// </summary>
    public static class IDataReaderExtensions
    {
        /// <summary>
        /// Gets the value or return default.
        /// </summary>
        /// <typeparam name="T">參考型別。</typeparam>
        /// <param name="reader">The reader.</param>
        /// <param name="columnIndex">Index of the column.</param>
        /// <returns>
        /// value.
        /// </returns>
        public static T GetValueOrDefault<T>(this IDataReader reader, int columnIndex)
        {
            if (reader.IsDBNull(columnIndex))
            {
                return default(T);
            }

            return (T)reader.GetValue(columnIndex);
        }

        /// <summary>
        /// 逐筆讀取 IDataReader 並將其轉成多筆 T 的個體。
        /// </summary>
        /// <typeparam name="T">多筆資料的型別。</typeparam>
        /// <param name="reader">The reader.</param>
        /// <param name="converter">轉換方法。</param>
        /// <returns>多筆 T 的個體。</returns>
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

        /// <summary>
        /// 轉換第一筆 T 的個體。
        /// </summary>
        /// <typeparam name="T">多筆資料的型別。</typeparam>
        /// <param name="reader">The reader.</param>
        /// <param name="converter">轉換方法。</param>
        /// <returns>第一筆 T 的個體。</returns>
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