using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace Yahoo.DataAccess.Common
{
    public class UserDao : CommonDao, IUserDao
    {
        public UserDao()
            : base("security")
        {
        }

        UserData IUserDao.GetOne(int id)
        {
            using (var connection = base.CreateConnection())
            {
                using (var dbCommand = connection.CreateCommand())
                {
                    var p = dbCommand.CreateParameter();
                    p.ParameterName = "@priuser_id";
                    p.Value = id;
                    dbCommand.Parameters.Add(p);

                    dbCommand.CommandType = CommandType.Text;
                    dbCommand.CommandText = base.Resource.GetString("GetOne.sql");

                    using (var reader = dbCommand.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new UserData
                            {
                                Id = reader.GetInt32(0),
                                Name = reader.GetString(1),
                                FullName = reader.GetString(2),
                                Department = reader.GetString(3),
                                Degree = reader.GetInt32(4),
                                Homepage = reader.GetString(5),
                                ExtensionNumber = reader.GetString(6),
                                BackyardId = reader.GetString(7)
                            };
                        }
                    }
                }
            }

            return null;
        }
    }
}
