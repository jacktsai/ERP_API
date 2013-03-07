using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ErpApi.Data;
using ErpApi.Data.Common;

namespace ErpApi.Services
{
    /// <summary>
    /// 第一個 <see cref="IServiceAdapter"/> 介面的實作。
    /// </summary>
    internal class ServiceAdapter : IServiceAdapter
    {
        private readonly IDaoFactory _factory;

        public ServiceAdapter()
        {
            this._factory = new CommonDaoFactory();
        }

        IUserService IServiceAdapter.GetUserService()
        {
            return new UserService(this._factory);
        }

        IAuthorizationService IServiceAdapter.GetAuthorizationService()
        {
            return new AuthorizationService(this._factory);
        }

        ISubCategoryService IServiceAdapter.GetSubCategoryService()
        {
            return new SubCategoryService(this._factory);
        }
    }
}