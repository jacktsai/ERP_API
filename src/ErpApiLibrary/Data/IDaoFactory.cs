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
        /// <returns></returns>
        IUserDao GetUserDao();

        /// <summary>
        /// 取得授權資料存取介面。
        /// </summary>
        /// <returns></returns>
        IAuthorityDao GetAuthorityDao();

        /// <summary>
        /// 取得子站資料存取介面。
        /// </summary>
        /// <returns></returns>
        ISubCategoryDao GetSubCategoryDao();
    }
}
