using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ErpApi.Data
{
    /// <summary>
    /// 使用者資料存取介面。
    /// </summary>
    public interface IUserDao
    {
        /// <summary>
        /// 取得乙筆使用者資料。
        /// </summary>
        /// <param name="backyardId">Backyard ID。</param>
        /// <returns></returns>
        UserData GetOne(string backyardId);

        /// <summary>
        /// 取得多筆使用者資料。
        /// </summary>
        /// <param name="userNames"></param>
        /// <returns></returns>
        IEnumerable<UserData> GetMany(IEnumerable<string> userNames);
    }
}
