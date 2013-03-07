using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ErpApi.Services
{
    /// <summary>
    /// A service interface of user informations.
    /// </summary>
    public interface IUserService
    {
        /// <summary>
        /// 取得操作者相關資訊。
        /// </summary>
        /// <param name="backyardId"></param>
        /// <returns></returns>
        Profile GetProfile(string backyardId);
    }
}
