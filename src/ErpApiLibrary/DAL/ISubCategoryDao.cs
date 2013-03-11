using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ErpApi.Entities;

namespace ErpApi.DAL
{
    /// <summary>
    /// 子站資料存取介面。
    /// </summary>
    public interface ISubCategoryDao
    {
        /// <summary>
        /// 以 user ID 搜尋子站資料。
        /// </summary>
        /// <param name="userId">user ID。</param>
        /// <returns>多筆子站資料。</returns>
        IEnumerable<SubCategory> GetMany(int userId);

        /// <summary>
        /// 以子站代碼搜尋子站資料。
        /// </summary>
        /// <param name="ids">多重子站代碼。</param>
        /// <returns>多筆子站資料。</returns>
        IEnumerable<SubCategory> GetMany(IEnumerable<int> ids);
    }
}
