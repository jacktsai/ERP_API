using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace ErpApi.Data.Common
{
    public class SubCategoryDao : CommonDao, ISubCategoryDao
    {
        public SubCategoryDao()
            : base("sale")
        {
        }

        IEnumerable<SubCategoryData> ISubCategoryDao.GetMany(int userId)
        {
            return base.ExecuteCommand(dbCommand =>
            {
                dbCommand.CommandType = CommandType.Text;
                dbCommand.CommandText = base.Resource.GetString("GetMany_userId.sql");

                dbCommand.AddParameterWithValue("@userId", userId);

                using (var reader = dbCommand.ExecuteReader())
                {
                    return reader.ToObjects(r => new SubCategoryData
                    {
                        Id = r.GetInt32(0),
                    });
                }
            });
        }

        IEnumerable<SubCategoryData> ISubCategoryDao.GetMany(IEnumerable<int> ids)
        {
            if (ids == null)
            {
                throw new ArgumentNullException("ids");
            }
            if (ids.Count() == 0)
            {
                throw new ArgumentOutOfRangeException("ids");
            }

            var format = base.Resource.GetString("GetMany_ids.sql");
            var sql = string.Format(format, string.Join(",", ids));

            return base.ExecuteCommand(dbCommand =>
            {
                dbCommand.CommandType = CommandType.Text;
                dbCommand.CommandText = sql;

                using (var reader = dbCommand.ExecuteReader())
                {
                    return reader.ToObjects(r => new SubCategoryData
                    {
                        Id = r.GetInt32(0),
                        PmName = r.GetValue<string>(1),
                        ManagerName = r.GetValue<string>(2),
                        PurchaserName = r.GetValue<string>(3),
                        StaffName = r.GetValue<string>(4),
                    });
                }
            });
        }
    }
}
