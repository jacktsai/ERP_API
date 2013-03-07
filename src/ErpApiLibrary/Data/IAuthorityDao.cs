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
        /// 取得乙筆。
        /// </summary>
        /// <param name="backyardId">Backyard ID。</param>
        /// <param name="url">URL。</param>
        /// <returns>使用者權限資料。</returns>
        AuthorityData GetOne(string backyardId, string url);
    }
}
