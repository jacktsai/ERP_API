using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Common;
using System.Configuration;
using Yahoo.Data.Common.Resources;
using System.Threading.Tasks;

namespace Yahoo.Data.Common
{
    public abstract class CommonDao
    {
        readonly ConnectionStringSettings settings;
        readonly DbProviderFactory factory;
        readonly Resource resource;

        protected CommonDao(string connectionStringName)
        {
            if (connectionStringName == null)
            {
                throw new ArgumentNullException("connectionStringName");
            }

            var settings = ConfigurationManager.ConnectionStrings[connectionStringName];
            if (settings == null)
            {
                throw new MissingConnectionStringSettingsException(connectionStringName);
            }

            this.settings = settings;
            this.factory = DbProviderFactories.GetFactory(settings.ProviderName);
            this.resource = new Resource(this);
        }

        public ConnectionStringSettings Settings { get { return this.settings; } }

        public DbProviderFactory Factory { get { return this.factory; } }

        public Resource Resource { get { return this.resource; } }

        protected DbConnection CreateConnection()
        {
            var connection = this.factory.CreateConnection();
            connection.ConnectionString = this.settings.ConnectionString;
            connection.Open();
            return connection;
        }

        protected Task<T> CreateTask<T>(Func<DbCommand, T> commandProcessor)
        {
            var task = Task.Factory.StartNew<T>(() =>
            {
                using (var connection = this.CreateConnection())
                {
                    using (var dbCommand = connection.CreateCommand())
                    {
                        return commandProcessor(dbCommand);
                    }
                }
            });

            return task;
        }
    }
}
