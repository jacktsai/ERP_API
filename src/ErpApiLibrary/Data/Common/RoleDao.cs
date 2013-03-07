using System;
using System.Collections.Generic;
using System.Data;

namespace ErpApi.Data.Common
{
    /// <summary>
    /// 以 System.Data.Common 為基礎所建立的 <see cref="IRoleDao"/> 介面實作。
    /// </summary>
    public class RoleDao : CommonDao, IRoleDao
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RoleDao" /> class.
        /// </summary>
        public RoleDao()
            : base("security")
        {
        }

        /// <summary>
        /// 取得多筆角色資料。
        /// </summary>
        /// <param name="userId">使用者序號。</param>
        /// <param name="url">URL。</param>
        /// <returns>
        /// 多筆角色資料。
        /// </returns>
        /// <exception cref="System.ArgumentNullException">url</exception>
        IEnumerable<RoleData> IRoleDao.GetMany(int userId, string url)
        {
            if (url == null)
            {
                throw new ArgumentNullException("url");
            }

            return this.ExecuteCommand(dbCommand =>
            {
                dbCommand.CommandType = CommandType.Text;
                dbCommand.CommandText = this.Resource.GetString("GetMany_userId_url.sql");

                dbCommand.AddParameterWithValue("@userId", userId);
                dbCommand.AddParameterWithValue("@url", url);

                using (var reader = dbCommand.ExecuteReader())
                {
                    return reader.ToObjects(Converter);
                }
            });
        }

        /// <summary>
        /// 將資料轉換成 RoleData 個體。
        /// </summary>
        /// <param name="r">IDataReader 個體。</param>
        /// <returns>RoleData 個體。</returns>
        private RoleData Converter(IDataReader r)
        {
            return new RoleData
            {
                Id = r.GetInt32(0),
                Name = r.GetString(1),
                Note = r.GetString(2),
                CanSelect = r.GetValueOrDefault<bool?>(3),
                CanInsert = r.GetValueOrDefault<bool?>(4),
                CanUpdate = r.GetValueOrDefault<bool?>(5),
                CanDelete = r.GetValueOrDefault<bool?>(6),
                CanParticular = r.GetValueOrDefault<bool?>(7),
            };
        }
    }
}