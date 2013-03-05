using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yahoo.Data
{
    /// <summary>
    /// 使用者權限資料存取介面。
    /// </summary>
    public interface IPrivilegeDao
    {
        /// <summary>
        /// 取得多筆。
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        Task<IEnumerable<PrivilegeData>> GetManyAsync(int userId);

        /// <summary>
        /// 取得乙筆。
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="url"></param>
        /// <returns></returns>
        Task<PrivilegeData> GetOneAsync(int userId, string url);
    }
}
