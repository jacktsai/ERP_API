using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Yahoo.Business.Security
{
    /// <summary>
    /// 使用者授權介面。
    /// </summary>
    public interface IAuthorizationService
    {
        /// <summary>
        /// 授權。
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="privilegeId"></param>
        void Authorize(int userId, int privilegeId);

        /// <summary>
        /// 取消授權。
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="privilegeId"></param>
        void Unauthorize(int userId, int privilegeId);

        /// <summary>
        /// 取得已授權的資訊。
        /// </summary>
        /// <param name="userId">User ID。</param>
        /// <returns>如果成功，回傳權限資訊；否則回傳 null。</returns>
        IEnumerable<PrivilegeInfo> GetPrivileges(int userId);
    }
}
