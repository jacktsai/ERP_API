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
            if (id == null && name == null && backyardId == null)
            {
                throw new InvalidOperationException("At least one parameter value is required!");
            }

            return base.CreateTask(dbCommand =>
            {
                dbCommand.CommandType = CommandType.Text;
                dbCommand.CommandText = base.Resource.GetString("GetOneAsync_id_name_backyardId.sql");

                dbCommand.AddParameterWithValue("@id", id);
                dbCommand.AddParameterWithValue("@name", name);
                dbCommand.AddParameterWithValue("@backyardId", backyardId);

                using (var reader = dbCommand.ExecuteReader())
                {
                    return reader.ToObject(Converter);
                }
            });
        }

        protected virtual UserData Converter(IDataReader reader)
        {
            return new UserData
            {
                Id = reader.GetInt32(0),
                Name = reader.GetValue<string>(1),
                FullName = reader.GetValue<string>(2),
                Department = reader.GetValue<string>(3),
                Degree = reader.GetByte(4),
                Email = reader.GetValue<string>(5),
                Homepage = reader.GetValue<string>(6),
                ExtNumber = reader.GetValue<string>(7),
                BackyardId = reader.GetValue<string>(8)
            };
        }
    }
}
