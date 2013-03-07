using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ErpApi.Services
{
    /// <summary>
    /// A service interface of user authorzation.
    /// </summary>
    public interface IAuthorizationService
    {
        /// <summary>
        /// 取得操作者 URL 的權限資訊。
        /// </summary>
        /// <param name="backyardId"></param>
        /// <returns></returns>
        Authority GetAuthority(string backyardId, string url);
    }
}
