namespace System.Data
{
    /// <summary>
    /// IDbCommand 的擴充方法。
    /// </summary>
    public static class IDbCommandExtensions
    {
        /// <summary>
        /// Adds the parameter with value.
        /// </summary>
        /// <typeparam name="T">The type of value.</typeparam>
        /// <param name="dbCommand">The db command.</param>
        /// <param name="parameterName">Name of the parameter.</param>
        /// <param name="value">The value.</param>
        /// <returns>An instance of IDataParameter.</returns>
        public static IDataParameter AddParameterWithValue<T>(this IDbCommand dbCommand, string parameterName, T value)
        {
            if (dbCommand == null)
            {
                throw new ArgumentNullException("dbCommand");
            }

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