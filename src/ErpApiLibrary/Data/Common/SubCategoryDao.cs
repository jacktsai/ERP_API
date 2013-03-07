using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace ErpApi.Data.Common
{
    /// <summary>
    /// 以 System.Data.Common 為基礎所建立的 <see cref="ISubCategoryDao"/> 介面實作。
    /// </summary>
    public class SubCategoryDao : CommonDao, ISubCategoryDao
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SubCategoryDao" /> class.
        /// </summary>
        public SubCategoryDao()
            : base("sale")
        {
        }

        /// <summary>
        /// 以 user ID 搜尋子站資料。
        /// </summary>
        /// <param name="userId">user ID。</param>
        /// <returns>
        /// 多筆子站資料。
        /// </returns>
        IEnumerable<SubCategoryData> ISubCategoryDao.GetMany(int userId)
        {
            return this.ExecuteCommand(dbCommand =>
            {
                dbCommand.CommandType = CommandType.Text;
                dbCommand.CommandText = this.Resource.GetString("GetMany_userId.sql");

                dbCommand.AddParameterWithValue("@userId", userId);

                using (var reader = dbCommand.ExecuteReader())
                {
                    return reader.ToObjects(r => new SubCategoryData
                    {
                        Id = r.GetInt32(0),
                    });
                }
            });
        }

        /// <summary>
        /// 以子站代碼搜尋子站資料。
        /// </summary>
        /// <param name="ids">多重子站代碼。</param>
        /// <returns>
        /// 多筆子站資料。
        /// </returns>
        /// <exception cref="System.ArgumentNullException">ids</exception>
        /// <exception cref="System.ArgumentOutOfRangeException">ids</exception>
        IEnumerable<SubCategoryData> ISubCategoryDao.GetMany(IEnumerable<int> ids)
        {
            if (ids == null)
            {
                throw new ArgumentNullException("ids");
            }

            if (ids.Count() == 0)
            {
                throw new ArgumentOutOfRangeException("ids");
            }

            var format = this.Resource.GetString("GetMany_ids.sql");
            var sql = string.Format(format, string.Join(",", ids));

            return this.ExecuteCommand(dbCommand =>
            {
                dbCommand.CommandType = CommandType.Text;
                dbCommand.CommandText = sql;

                using (var reader = dbCommand.ExecuteReader())
                {
                    return reader.ToObjects(r => new SubCategoryData
                    {
                        Id = r.GetInt32(0),
                        PmName = r.GetValue<string>(1),
                        ManagerName = r.GetValue<string>(2),
                        PurchaserName = r.GetValue<string>(3),
                        StaffName = r.GetValue<string>(4),
                    });
                }
            });
        }
    }
}