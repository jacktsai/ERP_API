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

        Task<IEnumerable<SubCategoryData>> ISubCategoryDao.GetManyAsync(int userId)
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

        Task<SubCategoryData> ISubCategoryDao.GetOneAsync(int id)
        {
            return base.CreateTask(dbCommand =>
            {
                dbCommand.CommandType = CommandType.Text;
                dbCommand.CommandText = base.Resource.GetString("GetOneAsync_id.sql");

                #region Parameters

                var idParameter = dbCommand.CreateParameter();
                idParameter.ParameterName = "@id";
                idParameter.Value = id;
                dbCommand.Parameters.Add(idParameter);

                #endregion

                using (var reader = dbCommand.ExecuteReader())
                {
                    return reader.ToObject(Converter);
                }
            });
        }

        protected virtual SubCategoryData Converter(IDataReader r)
        {
            return new SubCategoryData
            {
                Id = r.GetInt32(0),
                Name = r.GetValue<string>(1),
                ZoneId = r.GetInt16(2),
                UserName = r.GetValue<string>(3),
                ManagerName = r.GetValue<string>(4),
                PurchaserName = r.GetValue<string>(5),
                StaffName = r.GetValue<string>(6)
            };
        }
    }
}
