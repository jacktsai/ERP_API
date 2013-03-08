using System;
using System.Data;

namespace ErpApi.Data.Common
{
    /// <summary>
    /// 以 System.Data.Common 為基礎所建立的 <see cref="IDenyPrivilegeDao"/> 介面實作。
    /// </summary>
    public class DenyPrivilegeDao : CommonDao, IDenyPrivilegeDao
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DenyPrivilegeDao" /> class.
        /// </summary>
        public DenyPrivilegeDao()
            : base("security")
        {
        }

        /// <summary>
        /// 取得Deny Privilege Data。
        /// </summary>
        /// <param name="userId">使用者序號。</param>
        /// <param name="url">URL。</param>
        /// <returns>
        /// Deny Privilege Data。
        /// </returns>
        /// <exception cref="System.ArgumentNullException">url</exception>
        DenyPrivilegeData IDenyPrivilegeDao.GetOne(int userId, string url)
        {
            if (url == null)
            {
                throw new ArgumentNullException("url");
            }

            return this.ExecuteCommand(dbCommand =>
            {
                dbCommand.CommandType = CommandType.Text;
                dbCommand.CommandText = this.Resource.GetString("GetOne_userId_url.sql");

                dbCommand.AddParameterWithValue("@userId", userId);
                dbCommand.AddParameterWithValue("@url", url);

                using (var reader = dbCommand.ExecuteReader())
                {
                    return reader.ToObject(Converter);
                }
            });
        }

        /// <summary>
        /// 讀取 IDataReader 並傳回Deny Privilege Data。
        /// </summary>
        /// <param name="r">IDataReader 個體。</param>
        /// <returns>Deny Privilege Data。</returns>
        private DenyPrivilegeData Converter(IDataReader r)
        {
            return new DenyPrivilegeData
            {
                Id = r.GetInt32(0),
                UserId = r.GetInt32(1),
                Url = r.GetString(2),
                DenySelect = r.GetBoolean(3),
                DenyInsert = r.GetBoolean(4),
                DenyUpdate = r.GetBoolean(5),
                DenyDelete = r.GetBoolean(6),
                DenyParticular = r.GetBoolean(7),
            };
        }
    }
}