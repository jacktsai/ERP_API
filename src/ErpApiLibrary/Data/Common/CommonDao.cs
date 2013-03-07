using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Common;
using System.Configuration;
using ErpApi.Data.Common.Resources;
using System.Threading.Tasks;

namespace ErpApi.Data.Common
{
    public abstract class CommonDao
    {
        private readonly ConnectionStringSettings _settings;
        private readonly DbProviderFactory _factory;
        private readonly Resource _resource;

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

            this._settings = settings;
            this._factory = DbProviderFactories.GetFactory(settings.ProviderName);
            this._resource = new Resource(this);
        }

        public ConnectionStringSettings Settings { get { return this._settings; } }

        public DbProviderFactory Factory { get { return this._factory; } }

        public Resource Resource { get { return this._resource; } }

        protected DbConnection CreateConnection()
        {
            var connection = this._factory.CreateConnection();
            connection.ConnectionString = this._settings.ConnectionString;
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

        protected T ExecuteCommand<T>(Func<DbCommand, T> commandProcessor)
        {
            using (var connection = this.CreateConnection())
            {
                using (var dbCommand = connection.CreateCommand())
                {
                    return commandProcessor(dbCommand);
                }
            }
        }
    }
}
