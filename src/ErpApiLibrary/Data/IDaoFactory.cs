using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ErpApi.Data;

namespace ErpApi.Data
{
    /// <summary>
    /// 資料介面的工廠介面。
    /// </summary>
    public interface IDaoFactory
    {
        /// <summary>
        /// 取得使用者資料存取介面。
        /// </summary>
        /// <returns>
        /// 使用者資料存取介面。
        /// </returns>
        IUserDao GetUserDao();

        /// <summary>
        /// 取得角色資料存取介面。
        /// </summary>
        /// <returns>
        /// 角色資料存取介面。
        /// </returns>
        IRoleDao GetRoleDao();

        /// <summary>
        /// 取得使用者功能授權資料存取介面。
        /// </summary>
        /// <returns>
        /// 使用者功能授權資料存取介面。
        /// </returns>
        IPrivilegeDao GetPrivilegeDao();

        /// <summary>
        /// 取得拒絕權限資料存取介面。
        /// </summary>
        /// <returns>
        /// 拒絕權限資料存取介面。
        /// </returns>
        IDenyPrivilegeDao GetDenyPrivilegeDao();

        /// <summary>
        /// 取得子站資料存取介面。
        /// </summary>
        /// <returns>
        /// 子站資料存取介面。
        /// </returns>
        ISubCategoryDao GetSubCategoryDao();
    }
}
