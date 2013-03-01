using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Threading.Tasks;

namespace Yahoo.DataAccess.Common
{
    public class UserDao : CommonDao, IUserDao
    {
        public UserDao()
            : base("security")
        {
        }

        Task<UserData> IUserDao.GetOneAsync(string backyardId)
        {
            var task = Task.Factory.StartNew<UserData>(() =>
            {
                using (var connection = base.CreateConnection())
                {
                    using (var dbCommand = connection.CreateCommand())
                    {
                        var p = dbCommand.CreateParameter();
                        p.ParameterName = "@backyard_id";
                        p.Value = backyardId;
                        dbCommand.Parameters.Add(p);

                        dbCommand.CommandType = CommandType.Text;
                        dbCommand.CommandText = base.Resource.GetString("GetOneAsync_backyardId.sql");

                        using (var reader = dbCommand.ExecuteReader())
                        {
                            return reader.ToObject(r => new UserData
                            {
                                Id = reader.GetInt32(0),
                                Name = reader.GetString(1),
                                FullName = reader.GetString(2),
                                Department = reader.GetString(3),
                                Degree = reader.GetByte(4),
                                Homepage = reader.GetString(5),
                                ExtensionNumber = reader.GetString(6),
                                BackyardId = reader.GetString(7)
                            });
                        }
                    }
                }
            });

            return task;
        }
    }
}
