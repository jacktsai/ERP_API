using System.Collections.Generic;
using ErpApi.Entities;

namespace ErpApi.DAL
{
    /// <summary>
    /// 使用者資料存取介面。
    /// </summary>
    public interface IUserDao
    {
        /// <summary>
        /// 取得使用者資料。
        /// </summary>
        /// <param name="backyardId">Backyard ID。</param>
        /// <returns>使用者資料。</returns>
        User GetOne(string backyardId);

        /// <summary>
        /// 取得多筆使用者資料。
        /// </summary>
        /// <param name="userNames">多個使用者帳號。</param>
        /// <returns>多筆使用者資料。</returns>
        IEnumerable<User> GetMany(IEnumerable<string> userNames);
    }
}