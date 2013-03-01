using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yahoo.Business
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
        string Name { get; set; }

        /// <summary>
        /// 中文姓名
        /// </summary>
        string FullName { get; set; }

        /// <summary>
        /// 部門。
        /// </summary>
        string Department { get; set; }

        /// <summary>
        /// 等級。
        /// </summary>
        byte Degree { get; set; }

        /// <summary>
        /// 首頁。
        /// </summary>
        string Homepage { get; set; }

        /// <summary>
        /// 分機號碼。
        /// </summary>
        string ExtensionNumber { get; set; }

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
        /// 取得使用者分類權限集合
        /// </summary>
        ICatPrivilegeCollection CatPrivileges { get; }

        /// <summary>
        /// 載入使用者資料。
        /// </summary>
        /// <param name="userId">使用者編號。</param>
        /// <returns>成功為 True；否則為 False。</returns>
        Task LoadAsync(string backyardId);

        /// <summary>
        /// 寫入使用者資料。
        /// </summary>
        /// <returns>成功為 True；否則為 False。</returns>
        Task SaveAsync();
    }
}
