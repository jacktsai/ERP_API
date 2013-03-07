using System;
using System.Configuration;
using System.Data.Common;
using ErpApi.Data.Common.Resources;

namespace ErpApi.Data.Common
{
    /// <summary>
    /// 以 System.Data.Common 為基礎所建立的資料存取介面實作的基礎類別。
    /// </summary>
    public abstract class CommonDao
    {
        /// <summary>
        /// 資料庫連線設定。
        /// </summary>
        private readonly ConnectionStringSettings _settings;

        /// <summary>
        /// <see cref="System.Data.Common.DbProviderFactory"/> 的執行個體。
        /// </summary>
        private readonly DbProviderFactory _factory;

        /// <summary>
        /// <see cref="ErpApi.Data.Common.Resources.Resource"/> 的執行個體。
        /// </summary>
        private readonly Resource _resource;

        /// <summary>
        /// Initializes a new instance of the <see cref="CommonDao" /> class.
        /// </summary>
        /// <param name="connectionStringName">Name of the connection string.</param>
        /// <exception cref="System.ArgumentNullException">connectionStringName</exception>
        /// <exception cref="MissingConnectionStringSettingsException"></exception>
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

        /// <summary>
        /// 取得資料庫連線設定。
        /// </summary>
        /// <value>
        /// 資料庫連線設定。
        /// </value>
        public ConnectionStringSettings Settings
        {
            get { return this._settings; }
        }

        /// <summary>
        /// 取得 <see cref="System.Data.Common.DbProviderFactory"/> 的執行個體。
        /// </summary>
        /// <value>
        /// <see cref="System.Data.Common.DbProviderFactory"/> 的執行個體。
        /// </value>
        public DbProviderFactory Factory
        {
            get { return this._factory; }
        }

        /// <summary>
        /// 取得 <see cref="ErpApi.Data.Common.Resources.Resource"/> 的執行個體。
        /// </summary>
        /// <value>
        /// <see cref="ErpApi.Data.Common.Resources.Resource"/> 的執行個體。
        /// </value>
        public Resource Resource
        {
            get { return this._resource; }
        }

        /// <summary>
        /// Creates the connection.
        /// </summary>
        /// <returns>An instance of DbConnection.</returns>
        protected DbConnection CreateConnection()
        {
            var connection = this._factory.CreateConnection();
            connection.ConnectionString = this._settings.ConnectionString;
            connection.Open();
            return connection;
        }

        /// <summary>
        /// 建立一個 DbCommand 後交由 commandProcessor 處理，並傳回結果。
        /// </summary>
        /// <typeparam name="T">結果的型別。</typeparam>
        /// <param name="commandProcessor">The command processor.</param>
        /// <returns>
        /// 執行結果。
        /// </returns>
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