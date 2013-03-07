using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace ErpApi.Data.Common
{
    /// <summary>
    /// 以 System.Data.Common 為基礎所建立的 <see cref="IUserDao"/> 介面實作。
    /// </summary>
    public class UserDao : CommonDao, IUserDao
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UserDao" /> class.
        /// </summary>
        public UserDao()
            : base("security")
        {
        }

        /// <summary>
        /// 取得乙筆使用者資料。
        /// </summary>
        /// <param name="backyardId">Backyard ID。</param>
        /// <returns>
        /// 使用者資料。
        /// </returns>
        /// <exception cref="System.ArgumentNullException">backyardId</exception>
        UserData IUserDao.GetOne(string backyardId)
        {
            if (backyardId == null)
            {
                throw new ArgumentNullException("backyardId");
            }

            return this.ExecuteCommand(dbCommand =>
            {
                dbCommand.CommandType = CommandType.Text;
                dbCommand.CommandText = this.Resource.GetString("GetOne_backyardId.sql");

                dbCommand.AddParameterWithValue("@backyardId", backyardId);

                using (var reader = dbCommand.ExecuteReader())
                {
                    return reader.ToObject(Converter);
                }
            });
        }

        /// <summary>
        /// 取得多筆使用者資料。
        /// </summary>
        /// <param name="userNames">多個使用者姓名。</param>
        /// <returns>
        /// 多筆使用者資料。
        /// </returns>
        /// <exception cref="System.ArgumentNullException">userNames</exception>
        /// <exception cref="System.ArgumentOutOfRangeException">userNames</exception>
        /// <exception cref="System.NotImplementedException"></exception>
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

            var format = this.Resource.GetString("GetMany_userNames.sql");
            var wrappedUserNames = userNames.Select(s => string.Format("'{0}'", s)); // 給每個值的前後加上單引號。
            var sql = string.Format(format, string.Join(",", wrappedUserNames));

            return this.ExecuteCommand(dbCommand =>
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

        /// <summary>
        /// 將資料轉換成 UserData 個體。
        /// </summary>
        /// <param name="reader">The reader.</param>
        /// <returns>
        /// UserData 個體。
        /// </returns>
        private UserData Converter(IDataReader reader)
        {
            return new UserData
            {
                Id = reader.GetInt32(0),
                Name = reader.GetValueOrDefault<string>(1),
                FullName = reader.GetValueOrDefault<string>(2),
                Department = reader.GetValueOrDefault<string>(3),
                Degree = reader.GetByte(4),
                Email = reader.GetValueOrDefault<string>(5),
                Homepage = reader.GetValueOrDefault<string>(6),
                ExtNumber = reader.GetValueOrDefault<string>(7),
                BackyardId = reader.GetValueOrDefault<string>(8)
            };
        }
    }
}