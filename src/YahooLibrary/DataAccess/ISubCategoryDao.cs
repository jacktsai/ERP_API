using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yahoo.DataAccess
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
        /// <returns></returns>
        Task<IEnumerable<SubCategoryData>> GetManyAsync(int userId);

        /// <summary>
        /// 以子站代碼搜尋子站資料。
        /// </summary>
        /// <param name="id">子站代碼。</param>
        /// <returns></returns>
        Task<SubCategoryData> GetOneAsync(int id);
    }
}
