using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ErpApi.Data
{
    /// <summary>
    /// 授權資料存取介面。
    /// </summary>
    public interface IAuthorityDao
    {
        /// <summary>
        /// 取得多筆。
        /// </summary>
        /// <param name="backyardId">The backyard ID。</param>
        /// <param name="url">The URL。</param>
        /// <returns></returns>
        IEnumerable<AuthorityData> GetMany(string backyardId, string url);
    }
}
