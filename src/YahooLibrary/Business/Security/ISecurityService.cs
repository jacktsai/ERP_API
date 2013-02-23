using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Yahoo.Business.Security
{
    /// <summary>
    /// 網站安全性管理服務介面。
    /// </summary>
    public interface ISecurityService
    {
        /// <summary>
        /// 建立新的使用者資訊。
        /// </summary>
        /// <param name="userName">使用者名稱。</param>
        /// <param name="password">密碼。</param>
        /// <returns>如果認證成功，回傳 UserInfo；否則回傳 null。</returns>
        UserInfo CreateUser(string userName, string password);

        /// <summary>
        /// 刪除使用者資訊。
        /// </summary>
        /// <param name="userId">User ID。</param>
        void DeleteUser(int userId);

        /// <summary>
        /// 依照填入的 <see cref="UserInfo"/>.Id 更新其它使用者資訊。
        /// </summary>
        /// <param name="user">欲更新的使用者資料。</param>
        void UpdateUser(UserInfo user);

        /// <summary>
        /// 根據傳入的 userName 及 password 進行使用者認證。
        /// </summary>
        /// <param name="userName">使用者名稱。</param>
        /// <param name="password">密碼。</param>
        /// <returns>如果認證成功，回傳 UserInfo；否則回傳 null。</returns>
        UserInfo Authenticate(string userName, string password);

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
