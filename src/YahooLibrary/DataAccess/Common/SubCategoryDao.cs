using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace Yahoo.DataAccess.Common
{
    public class SubCategoryDao : CommonDao, ISubCategoryDao
    {
        public SubCategoryDao()
            : base("sale")
        {
        }

        Task<IEnumerable<SubCategoryData>> ISubCategoryDao.GetManyAsync(int userId)
        {
            var task = Task.Factory.StartNew<IEnumerable<SubCategoryData>>(() =>
            {
                using (var connection = base.CreateConnection())
                {
                    using (var dbCommand = connection.CreateCommand())
                    {
                        dbCommand.CommandType = CommandType.Text;
                        dbCommand.CommandText = base.Resource.GetString("GetManyAsync_userId.sql");

                        var userIdParameter = dbCommand.CreateParameter();
                        userIdParameter.ParameterName = "@userId";
                        userIdParameter.Value = userId;
                        dbCommand.Parameters.Add(userIdParameter);

                        using (var reader = dbCommand.ExecuteReader())
                        {
                            return reader.ToObjects(Converter);
                        }
                    }
                }
            });

            return task;
        }

        Task<SubCategoryData> ISubCategoryDao.GetOneAsync(int id)
        {
            var task = Task.Factory.StartNew<SubCategoryData>(() =>
            {
                using (var connection = base.CreateConnection())
                {
                    using (var dbCommand = connection.CreateCommand())
                    {
                        dbCommand.CommandType = CommandType.Text;
                        dbCommand.CommandText = base.Resource.GetString("GetOneAsync_id.sql");

                        var idParameter = dbCommand.CreateParameter();
                        idParameter.ParameterName = "@id";
                        idParameter.Value = id;
                        dbCommand.Parameters.Add(idParameter);

                        using (var reader = dbCommand.ExecuteReader())
                        {
                            return reader.ToObject(Converter);
                        }
                    }
                }
            });

            return task;
        }

        protected virtual SubCategoryData Converter(IDataReader r)
        {
            var data = new SubCategoryData
            {
                Id = r.GetInt32(0),
                Name = r.GetString(1),
                ZoneId = r.GetInt16(2),
                UserName = r.IsDBNull(3) ? null : r.GetString(3),
                ManagerName = r.IsDBNull(4) ? null : r.GetString(4),
                PurchaserName = r.IsDBNull(5) ? null : r.GetString(5),
                StaffName = r.IsDBNull(6) ? null : r.GetString(6)
            };

            return data;
        }
    }
}
