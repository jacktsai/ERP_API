using System.Collections.Generic;
using ErpApi.Entities;

namespace ErpApi.DAL
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
        IEnumerable<Role> GetMany(int userId, string url);
    }
}