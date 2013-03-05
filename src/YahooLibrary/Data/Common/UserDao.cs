using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Threading.Tasks;

namespace Yahoo.Data.Common
{
    public class UserDao : CommonDao, IUserDao
    {
        public UserDao()
            : base("security")
        {
        }

        Task<UserData> IUserDao.GetOneAsync(int? id, string name, string backyardId)
        {
            var task = Task.Factory.StartNew<UserData>(() =>
            {
                using (var connection = base.CreateConnection())
                {
                    using (var dbCommand = connection.CreateCommand())
                    {
                        dbCommand.CommandType = CommandType.Text;
                        dbCommand.CommandText = base.Resource.GetString("GetOneAsync_id_name_backyardId.sql");

                        #region Parameters

                        var idParameter = dbCommand.CreateParameter();
                        idParameter.ParameterName = "@id";
                        if (id != null)
                        {
                            idParameter.Value = id;
                        }
                        else
                        {
                            idParameter.Value = DBNull.Value;
                        }
                        dbCommand.Parameters.Add(idParameter);

                        var nameParameter = dbCommand.CreateParameter();
                        nameParameter.ParameterName = "@name";
                        if (name != null)
                        {
                            nameParameter.Value = name;
                        }
                        else
                        {
                            nameParameter.Value = DBNull.Value;
                        }
                        dbCommand.Parameters.Add(nameParameter);

                        var backyardIdParameter = dbCommand.CreateParameter();
                        backyardIdParameter.ParameterName = "@backyardId";
                        if (backyardId != null)
                        {
                            backyardIdParameter.Value = backyardId;
                        }
                        else
                        {
                            backyardIdParameter.Value = DBNull.Value;
                        }
                        dbCommand.Parameters.Add(backyardIdParameter);

                        #endregion

                        using (var reader = dbCommand.ExecuteReader())
                        {
                            return reader.ToObject(Converter);
                        }
                    }
                }
            });

            return task;
        }

        protected virtual UserData Converter(IDataReader reader)
        {
            return new UserData
            {
                Id = reader.GetInt32(0),
                Name = reader.GetString(1),
                FullName = reader.GetString(2),
                Department = reader.GetString(3),
                Degree = reader.GetByte(4),
                Email = reader.GetString(5),
                Homepage = reader.GetString(6),
                ExtNumber = reader.GetString(7),
                BackyardId = reader.GetString(8)
            };
        }
    }
}
