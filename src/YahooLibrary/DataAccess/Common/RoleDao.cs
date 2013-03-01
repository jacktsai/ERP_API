using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace Yahoo.DataAccess.Common
{
    public class RoleDao : CommonDao, IRoleDao
    {
        public RoleDao()
            : base("security")
        {
        }

        Task<IEnumerable<RoleData>> IRoleDao.GetManyAsync(int userId)
        {
            var task = Task.Factory.StartNew<IEnumerable<RoleData>>(() =>
            {
                using (var connection = base.CreateConnection())
                {
                    using (var dbCommand = connection.CreateCommand())
                    {
                        var p = dbCommand.CreateParameter();
                        p.ParameterName = "@user_id";
                        p.Value = userId;
                        dbCommand.Parameters.Add(p);

                        dbCommand.CommandType = CommandType.Text;
                        dbCommand.CommandText = base.Resource.GetString("GetManyAsync_userId.sql");

                        using (var reader = dbCommand.ExecuteReader())
                        {
                            return reader.ToObjects(r => new RoleData
                            {
                                Id = reader.GetInt32(0),
                                Name = reader.GetString(1),
                                CanSelect = r.IsDBNull(2) ? null : (bool?)r.GetBoolean(2),
                                CanInsert = r.IsDBNull(3) ? null : (bool?)r.GetBoolean(3),
                                CanUpdate = r.IsDBNull(4) ? null : (bool?)r.GetBoolean(4),
                                CanDelete = r.IsDBNull(5) ? null : (bool?)r.GetBoolean(5),
                                CanParticular = r.IsDBNull(6) ? null : (bool?)r.GetBoolean(6),
                            });
                        }
                    }
                }
            });

            return task;
        }
    }
}
