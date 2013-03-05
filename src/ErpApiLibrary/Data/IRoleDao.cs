using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ErpApi.Data
{
    /// <summary>
    /// 角色資料存取介面。
    /// </summary>
    public interface IRoleDao
    {
        /// <summary>
        /// 取得多筆角色資料。
        /// </summary>
        /// <param name="userId">User ID。</param>
        /// <returns></returns>
        Task<IEnumerable<RoleData>> GetManyAsync(int userId);
    }
}
