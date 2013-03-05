using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace ErpApi.Data.Common
{
    public class RoleDao : CommonDao, IRoleDao
    {
        public RoleDao()
            : base("security")
        {
        }

        Task<IEnumerable<RoleData>> IRoleDao.GetManyAsync(int userId)
        {
            return base.CreateTask(dbCommand =>
            {
                dbCommand.CommandType = CommandType.Text;
                dbCommand.CommandText = base.Resource.GetString("GetManyAsync_userId.sql");

                dbCommand.AddParameterWithValue("@userId", userId);

                using (var reader = dbCommand.ExecuteReader())
                {
                    return reader.ToObjects(Converter);
                }
            });
        }

        protected virtual RoleData Converter(IDataReader r)
        {
            return new RoleData
            {
                Id = r.GetInt32(0),
                Name = r.GetValue<string>(1),
                CanSelect = r.GetNullableValue<bool>(2),
                CanInsert = r.GetNullableValue<bool>(3),
                CanUpdate = r.GetNullableValue<bool>(4),
                CanDelete = r.GetNullableValue<bool>(5),
                CanParticular = r.GetNullableValue<bool>(6),
            };
        }
    }
}
