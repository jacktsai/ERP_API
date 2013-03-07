using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Threading.Tasks;

namespace ErpApi.Data.Common
{
    public class UserDao : CommonDao, IUserDao
    {
        public UserDao()
            : base("security")
        {
        }

        UserData IUserDao.GetOne(string backyardId)
        {
            if (backyardId == null)
            {
                throw new ArgumentNullException("backyardId");
            }

            return base.ExecuteCommand(dbCommand =>
            {
                dbCommand.CommandType = CommandType.Text;
                dbCommand.CommandText = base.Resource.GetString("GetOne_backyardId.sql");

                dbCommand.AddParameterWithValue("@backyardId", backyardId);

                using (var reader = dbCommand.ExecuteReader())
                {
                    return reader.ToObject(Converter);
                }
            });
        }

        IEnumerable<UserData> IUserDao.GetMany(IEnumerable<string> userNames)
        {
            if (userNames == null)
            {
                throw new ArgumentNullException("userNames");
            }
            if (userNames.Count() == 0)
            {
                throw new ArgumentOutOfRangeException("userNames");
            }

            var format = base.Resource.GetString("GetMany_userNames.sql");
            var wrappedUserNames = userNames.Select(s => string.Format("'{0}'", s)); //給每個值的前後加上單引號。
            var sql = string.Format(format, string.Join(",", wrappedUserNames));

            return base.ExecuteCommand(dbCommand =>
            {
                dbCommand.CommandType = CommandType.Text;
                dbCommand.CommandText = sql;

                using (var reader = dbCommand.ExecuteReader())
                {
                    return reader.ToObjects(Converter);
                }
            });
            throw new NotImplementedException();
        }

        private UserData Converter(IDataReader reader)
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
