using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ErpApi.Services
{
    /// <summary>
    /// 提供操作者相關的服務介面。
    /// </summary>
    public interface IUserService
    {
        /// <summary>
        /// 取得操作者相關資訊。
        /// </summary>
        /// <param name="backyardId">The backyard id.</param>
        /// <returns>
        /// 操作者相關資訊。
        /// </returns>
        Profile GetProfile(string backyardId);

        /// <summary>
        /// 取得操作者 URL 的權限資訊。
        /// </summary>
        /// <param name="backyardId">The backyard id.</param>
        /// <param name="url">The URL.</param>
        /// <returns>操作者 URL 的權限資訊。</returns>
        Authority GetAuthority(string backyardId, string url);
    }
}
