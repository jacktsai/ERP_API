using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace Yahoo.Data.Common
{
    public class AuthorityDao : CommonDao, IAuthorityDao
    {
        public AuthorityDao()
            : base("security")
        {
        }

        Task<IEnumerable<AuthorityData>> IAuthorityDao.GetManyAsync(int userId)
        {
            var task = Task.Factory.StartNew<IEnumerable<AuthorityData>>(() =>
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
                            return reader.ToObjects(Converter);
                        }
                    }
                }
            });

            return task;
        }

        Task<IEnumerable<AuthorityData>> IAuthorityDao.GetManyAsync(int userId, string url)
        {
            var task = Task.Factory.StartNew<IEnumerable<AuthorityData>>(() =>
            {
                using (var connection = base.CreateConnection())
                {
                    using (var dbCommand = connection.CreateCommand())
                    {
                        dbCommand.CommandType = CommandType.Text;
                        dbCommand.CommandText = base.Resource.GetString("GetManyAsync_userId_url.sql");

                        var userIdParameter = dbCommand.CreateParameter();
                        userIdParameter.ParameterName = "@user_id";
                        userIdParameter.Value = userId;
                        dbCommand.Parameters.Add(userIdParameter);

                        var urlParameter = dbCommand.CreateParameter();
                        urlParameter.ParameterName = "@url";
                        urlParameter.Value = url;
                        dbCommand.Parameters.Add(urlParameter);

                        using (var reader = dbCommand.ExecuteReader())
                        {
                            return reader.ToObjects(Converter);
                        }
                    }
                }
            });

            return task;
        }

        protected virtual AuthorityData Converter(IDataReader r)
        {
            return new AuthorityData
            {
                CanSelect = r.IsDBNull(0) ? null : (bool?)r.GetBoolean(0),
                CanInsert = r.IsDBNull(1) ? null : (bool?)r.GetBoolean(1),
                CanUpdate = r.IsDBNull(2) ? null : (bool?)r.GetBoolean(2),
                CanDelete = r.IsDBNull(3) ? null : (bool?)r.GetBoolean(3),
                CanParticular = r.IsDBNull(4) ? null : (bool?)r.GetBoolean(4),
                DenySelect = r.IsDBNull(5) ? null : (bool?)r.GetBoolean(5),
                DenyInsert = r.IsDBNull(6) ? null : (bool?)r.GetBoolean(6),
                DenyUpdate = r.IsDBNull(7) ? null : (bool?)r.GetBoolean(7),
                DenyDelete = r.IsDBNull(8) ? null : (bool?)r.GetBoolean(8),
                DenyParticular = r.IsDBNull(9) ? null : (bool?)r.GetBoolean(9),
            };
        }
    }
}
