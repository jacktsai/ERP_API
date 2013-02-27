using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
        int Degree { get; set; }

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
        string BackyardId { get; set; }

        /// <summary>
        /// 權限集合。
        /// </summary>
        IAuthorityCollection Authorities { get; }

        /// <summary>
        /// 嚐試載入使用者資料。
        /// </summary>
        /// <param name="userId">使用者編號。</param>
        /// <returns>成功為 True；否則為 False。</returns>
        bool TryLoad(int userId);

        /// <summary>
        /// 初始化為新的使用者資料個體。
        /// </summary>
        void New();

        /// <summary>
        /// 嚐試寫入使用者資料。
        /// </summary>
        /// <returns>成功為 True；否則為 False。</returns>
        bool TrySave();
    }
}
