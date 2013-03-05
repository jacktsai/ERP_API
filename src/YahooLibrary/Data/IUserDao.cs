using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yahoo.Data
{
    /// <summary>
    /// 使用者資料存取介面。
    /// </summary>
    public interface IUserDao
    {
        /// <summary>
        /// 取得乙筆使用者資料。
        /// </summary>
        /// <param name="id">User ID。</param>
        /// <param name="name">User Name。</param>
        /// <param name="backyardId">Backyard ID。</param>
        /// <returns></returns>
        Task<UserData> GetOneAsync(int? id = null, string name = null, string backyardId = null);
    }
}
