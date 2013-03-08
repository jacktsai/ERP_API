using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ErpApi.Services
{
    /// <summary>
    /// 服務提供者。
    /// </summary>
    public interface IServiceProvider
    {
        /// <summary>
        /// 取得 <see cref="ErpApi.Services.IUserService" /> 執行個體。
        /// </summary>
        /// <returns><see cref="IUserService" /> 執行個體。</returns>
        IUserService GetUserService();

        /// <summary>
        /// 取得 <see cref="ErpApi.Services.ISubCategoryService" /> 執行個體。
        /// </summary>
        /// <returns><see cref="ISubCategoryService" /> 執行個體。</returns>
        ISubCategoryService GetSubCategoryService();
    }
}
