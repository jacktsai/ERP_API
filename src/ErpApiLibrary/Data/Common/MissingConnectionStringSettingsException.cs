using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ErpApi.Data.Common
{
    /// <summary>
    /// 當找不到相對應的 ConnectionString setting 時應該發生的例外。
    /// </summary>
    public class MissingConnectionStringSettingsException : ApplicationException
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MissingConnectionStringSettingsException" /> class.
        /// </summary>
        /// <param name="connectionStringName">Name of the connection string setting.</param>
        public MissingConnectionStringSettingsException(string connectionStringName)
            : base(string.Format("Connection string '{0}' not found!", connectionStringName))
        {
        }
    }
}
