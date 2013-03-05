using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yahoo.Data
{
    /// <summary>
    /// 授權資料存取介面。
    /// </summary>
    public interface IAuthorityDao
    {
        /// <summary>
        /// 取得多筆。
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="url"></param>
        /// <returns></returns>
        Task<IEnumerable<AuthorityData>> GetManyAsync(int userId, string url);
    }
}
