using System;
using System.Collections.Generic;
using System.Data;

namespace ErpApi.Data.Common
{
    /// <summary>
    /// 以 System.Data.Common 為基礎所建立的 <see cref="IAuthorityDao"/> 介面實作。
    /// </summary>
    public class AuthorityDao : CommonDao, IAuthorityDao
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AuthorityDao" /> class.
        /// </summary>
        public AuthorityDao()
            : base("security")
        {
        }

        /// <summary>
        /// 取得乙筆。
        /// </summary>
        /// <param name="backyardId">Backyard ID。</param>
        /// <param name="url">URL。</param>
        /// <returns>
        /// 使用者權限資料。
        /// </returns>
        /// <exception cref="System.ArgumentNullException">url</exception>
        AuthorityData IAuthorityDao.GetOne(string backyardId, string url)
        {
            if (backyardId == null)
            {
                throw new ArgumentNullException("backyardId");
            }

            if (url == null)
            {
                throw new ArgumentNullException("url");
            }

            return this.ExecuteCommand(dbCommand =>
            {
                dbCommand.CommandType = CommandType.Text;
                dbCommand.CommandText = this.Resource.GetString("GetOne_backyardId_url.sql");

                dbCommand.AddParameterWithValue("@backyardId", backyardId);
                dbCommand.AddParameterWithValue("@url", url);

                using (var reader = dbCommand.ExecuteReader())
                {
                    return reader.ToObject(Converter);
                }
            });
        }

        /// <summary>
        /// 將資料轉換成 AuthorityData 個體。
        /// </summary>
        /// <param name="r">IDataReader 個體。</param>
        /// <returns>AuthorityData 個體。</returns>
        private AuthorityData Converter(IDataReader r)
        {
            return new AuthorityData
            {
                CanSelect = r.GetBoolean(0),
                CanInsert = r.GetBoolean(1),
                CanUpdate = r.GetBoolean(2),
                CanDelete = r.GetBoolean(3),
                CanParticular = r.GetBoolean(4),
                DenySelect = r.GetBoolean(5),
                DenyInsert = r.GetBoolean(6),
                DenyUpdate = r.GetBoolean(7),
                DenyDelete = r.GetBoolean(8),
                DenyParticular = r.GetBoolean(9),
            };
        }
    }
}