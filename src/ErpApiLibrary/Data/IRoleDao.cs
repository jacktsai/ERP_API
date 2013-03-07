using System.Collections.Generic;

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
        /// <param name="userId">使用者序號。</param>
        /// <param name="url">URL。</param>
        /// <returns>多筆角色資料。</returns>
        IEnumerable<RoleData> GetMany(int userId, string url);
    }
}