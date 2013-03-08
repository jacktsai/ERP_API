using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ErpApi.Data;
using ErpApi.Data.Common;

namespace ErpApi.Services
{
    /// <summary>
    /// 介面 <see cref="ErpApi.Services.IServiceProvider"/> 的實作。
    /// </summary>
    public class CommonServiceProvider : IServiceProvider
    {
        /// <summary>
        /// The <see cref="IDaoFactory"/> instance.
        /// </summary>
        private readonly IDaoFactory _factory;
        
        /// <summary>
        /// Initializes a new instance of the <see cref="CommonServiceProvider" /> class.
        /// </summary>
        public CommonServiceProvider()
        {
            this._factory = new CommonDaoFactory();
        }

        /// <summary>
        /// 取得 <see cref="ErpApi.Services.IUserService" /> 執行個體。
        /// </summary>
        /// <returns>
        ///   <see cref="IUserService" /> 執行個體。
        /// </returns>
        IUserService IServiceProvider.GetUserService()
        {
            return new UserService(this._factory);
        }

        /// <summary>
        /// 取得 <see cref="ErpApi.Services.ISubCategoryService" /> 執行個體。
        /// </summary>
        /// <returns>
        ///   <see cref="ISubCategoryService" /> 執行個體。
        /// </returns>
        ISubCategoryService IServiceProvider.GetSubCategoryService()
        {
            return new SubCategoryService(this._factory);
        }
    }
}
