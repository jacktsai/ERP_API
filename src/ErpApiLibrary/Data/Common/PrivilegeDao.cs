using System;
using System.Data;

namespace ErpApi.Data.Common
{
    /// <summary>
    /// 以 System.Data.Common 為基礎所建立的 <see cref="IPrivilegeDao"/> 介面實作。
    /// </summary>
    public class PrivilegeDao : CommonDao, IPrivilegeDao
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PrivilegeDao" /> class.
        /// </summary>
        public PrivilegeDao()
            : base("security")
        {
        }

        /// <summary>
        /// 取得 Privilege Data。
        /// </summary>
        /// <param name="backyardId">Backyard ID。</param>
        /// <param name="url">URL。</param>
        /// <returns>
        /// Privilege Data。
        /// </returns>
        /// <exception cref="System.ArgumentNullException">backyardId</exception>
        /// <exception cref="System.ArgumentNullException">url</exception>
        PrivilegeData IPrivilegeDao.GetOne(string backyardId, string url)
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
        /// 讀取 IDataReader 並傳Privilege Data。
        /// </summary>
        /// <param name="r">IDataReader 個體。</param>
        /// <returns>Privilege Data。</returns>
        private PrivilegeData Converter(IDataReader r)
        {
            return new PrivilegeData
            {
                Id = r.GetInt32(0),
                UserId = r.GetInt32(1),
                FunctionId = r.GetInt32(2),
                Note = r.GetString(3),
            };
        }
    }
}