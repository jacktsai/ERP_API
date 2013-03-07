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
        /// 取得乙筆。
        /// </summary>
        /// <param name="backyardId">Backyard ID。</param>
        /// <param name="url">URL。</param>
        /// <returns>
        /// 使用者權限資料。
        /// </returns>
        /// <exception cref="System.ArgumentNullException">backyardId or url is null.</exception>
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
        /// 將資料轉換成 PrivilegeData 個體。
        /// </summary>
        /// <param name="r">IDataReader 個體。</param>
        /// <returns>PrivilegeData 個體。</returns>
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