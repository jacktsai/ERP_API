using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Yahoo.DataAccess.Common
{
    public class MissingConnectionStringSettingsException : ApplicationException
    {
        public MissingConnectionStringSettingsException(string connectionStringName)
            : base(string.Format("Connection string '{0}' not found!", connectionStringName))
        {
        }
    }
}
