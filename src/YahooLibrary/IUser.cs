using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yahoo
{
    /// <summary>
    /// 表示一個使用者的商業邏輯個體。
    /// </summary>
    public interface IUser
    {
        /// <summary>
        /// 操作者編號。
        /// </summary>
        int Id { get; }

        /// <summary>
        /// 帳號。
        /// </summary>
        string Name { get; }

        /// <summary>
        /// 中文姓名
        /// </summary>
        string FullName { get; }

        /// <summary>
        /// 部門。
        /// </summary>
        string Department { get; }

        /// <summary>
        /// 等級。
        /// </summary>
        byte Degree { get; }

        /// <summary>
        /// 電子郵件位址。
        /// </summary>
        string Email { get; }

        /// <summary>
        /// 首頁。
        /// </summary>
        string Homepage { get; }

        /// <summary>
        /// 分機號碼。
        /// </summary>
        string ExtNumber { get; }

        /// <summary>
        /// Backyard ID。
        /// </summary>
        string BackyardId { get; }

        /// <summary>
        /// 取得使用者角色集合。
        /// </summary>
        IRoleCollection Roles { get; }

        /// <summary>
        /// 取得使用者功能權限集合。
        /// </summary>
        IPrivilegeCollection Privileges { get; }

        /// <summary>
        /// 取得使用者子站集合。
        /// </summary>
        ISubCategoryCollection SubCategories { get; }
    }
}
