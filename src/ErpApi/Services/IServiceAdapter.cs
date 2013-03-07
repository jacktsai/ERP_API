using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ErpApi.Services
{
    /// <summary>
    /// 服務介面轉接器。
    /// </summary>
    internal interface IServiceAdapter
    {
        /// <summary>
        /// 取得 <see cref="IUserService"/> 執行個體。
        /// </summary>
        /// <returns></returns>
        IUserService GetUserService();

        /// <summary>
        /// 取得 <see cref="IAuthorizationService"/> 執行個體。
        /// </summary>
        /// <returns></returns>
        IAuthorizationService GetAuthorizationService();

        /// <summary>
        /// 取得 <see cref="ISubCategoryService"/> 執行個體。
        /// </summary>
        /// <returns></returns>
        ISubCategoryService GetSubCategoryService();
    }
}
