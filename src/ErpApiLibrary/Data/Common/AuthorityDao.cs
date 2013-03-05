using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace ErpApi.Data.Common
{
    public class AuthorityDao : CommonDao, IAuthorityDao
    {
        public AuthorityDao()
            : base("security")
        {
        }

        Task<IEnumerable<AuthorityData>> IAuthorityDao.GetManyAsync(int userId, string url)
        {
            if (url == null)
            {
                throw new ArgumentNullException("url");
            }

            return base.CreateTask(dbCommand =>
            {
                dbCommand.CommandType = CommandType.Text;
                dbCommand.CommandText = base.Resource.GetString("GetManyAsync_userId_url.sql");

                dbCommand.AddParameterWithValue("@user_id", userId);
                dbCommand.AddParameterWithValue("@url", url);

                using (var reader = dbCommand.ExecuteReader())
                {
                    return reader.ToObjects(Converter);
                }
            });
        }

        protected virtual AuthorityData Converter(IDataReader r)
        {
            return new AuthorityData
            {
                CanSelect = r.GetNullableValue<bool>(0),
                CanInsert = r.GetNullableValue<bool>(1),
                CanUpdate = r.GetNullableValue<bool>(2),
                CanDelete = r.GetNullableValue<bool>(3),
                CanParticular = r.GetNullableValue<bool>(4),
                DenySelect = r.GetNullableValue<bool>(5),
                DenyInsert = r.GetNullableValue<bool>(6),
                DenyUpdate = r.GetNullableValue<bool>(7),
                DenyDelete = r.GetNullableValue<bool>(8),
                DenyParticular = r.GetNullableValue<bool>(9),
            };
        }
    }
}
