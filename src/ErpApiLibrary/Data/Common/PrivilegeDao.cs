using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using ErpApi.Data.Common.Resources;
using System.Threading.Tasks;

namespace ErpApi.Data.Common
{
    public class PrivilegeDao : CommonDao, IPrivilegeDao
    {
        public PrivilegeDao()
            : base("security")
        {
        }

        Task<IEnumerable<PrivilegeData>> IPrivilegeDao.GetManyAsync(int userId)
        {
            return base.CreateTask(dbCommand =>
            {
                dbCommand.CommandType = CommandType.Text;
                dbCommand.CommandText = base.Resource.GetString("GetManyAsync_userId.sql");

                dbCommand.AddParameterWithValue("@user_id", userId);

                using (var reader = dbCommand.ExecuteReader())
                {
                    return reader.ToObjects(Converter);
                }
            });
        }

        Task<PrivilegeData> IPrivilegeDao.GetOneAsync(int userId, string url)
        {
            return base.CreateTask(dbCommand =>
            {
                dbCommand.CommandType = CommandType.Text;
                dbCommand.CommandText = base.Resource.GetString("GetOneAsync_userId_url.sql");

                dbCommand.AddParameterWithValue("@user_id", userId);
                dbCommand.AddParameterWithValue("@url", url);

                using (var reader = dbCommand.ExecuteReader())
                {
                    return reader.ToObject(Converter);
                }
            });
        }

        protected virtual PrivilegeData Converter(IDataReader r)
        {
            return new PrivilegeData
            {
                Url = r.GetValue<string>(0),
                Name = r.GetValue<string>(1),
            };
        }
    }
}
