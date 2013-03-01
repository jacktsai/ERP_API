using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace Yahoo.DataAccess.Common
{
    public class CatPrivilegeDao : CommonDao, ICatPrivilegeDao
    {
        public CatPrivilegeDao()
            : base("sale")
        {
        }

        Task<IEnumerable<CatPrivilegeData>> ICatPrivilegeDao.GetManyAsync(int userId)
        {
            var task = Task.Factory.StartNew<IEnumerable<CatPrivilegeData>>(() =>
            {
                using (var connection = base.CreateConnection())
                {
                    using (var dbCommand = connection.CreateCommand())
                    {
                        dbCommand.CommandType = CommandType.Text;
                        dbCommand.CommandText = base.Resource.GetString("GetManyAsync_userId.sql");

                        var userIdParameter = dbCommand.CreateParameter();
                        userIdParameter.ParameterName = "@user_id";
                        userIdParameter.Value = userId;
                        dbCommand.Parameters.Add(userIdParameter);

                        using (var reader = dbCommand.ExecuteReader())
                        {
                            return reader.ToObjects(r => new CatPrivilegeData
                            {
                                ZoneId = r.GetInt16(0),
                                ZoneName = r.GetString(1),
                                SubId = r.GetInt32(2),
                                SubName = r.GetString(3),
                            });
                        }
                    }
                }
            });

            return task;
        }
    }
}
