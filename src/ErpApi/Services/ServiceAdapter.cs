using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ErpApi.Data;
using ErpApi.Data.Common;

namespace ErpApi.Services
{
    /// <summary>
    /// <see cref="IServiceAdapter" /> 介面的實作。
    /// </summary>
    internal class ServiceAdapter : IServiceAdapter
    {
        /// <summary>
        /// The <see cref="IServiceProvider"/> instance.
        /// </summary>
        private readonly IServiceProvider _provider;

        /// <summary>
        /// Initializes a new instance of the <see cref="ServiceAdapter" /> class.
        /// </summary>
        public ServiceAdapter()
        {
            this._provider = new CommonServiceProvider();
        }

        /// <summary>
        /// 取得 <see cref="IUserService" /> 執行個體。
        /// </summary>
        /// <returns>
        ///   <see cref="IUserService" /> 執行個體。
        /// </returns>
        IUserService IServiceAdapter.GetUserService()
        {
            return this._provider.GetUserService();
        }

        /// <summary>
        /// 取得 <see cref="ISubCategoryService" /> 執行個體。
        /// </summary>
        /// <returns>
        ///   <see cref="ISubCategoryService" /> 執行個體。
        /// </returns>
        ISubCategoryService IServiceAdapter.GetSubCategoryService()
        {
            return this._provider.GetSubCategoryService();
        }
    }
}