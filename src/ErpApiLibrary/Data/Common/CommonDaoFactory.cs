using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ErpApi.Data;

namespace ErpApi.Data.Common
{
    /// <summary>
    /// 介面 <see cref="IDaoFactory"/> 的實作類別。
    /// 此類別提供以 System.Data.Common 為基礎的資料存取架構。
    /// </summary>
    public class CommonDaoFactory : IDaoFactory
    {
        private IUserDao _userDao;

        IUserDao IDaoFactory.GetUserDao()
        {
            if (this._userDao == null)
            {
                this._userDao = new UserDao();
            }
            return this._userDao;
        }

        private IAuthorityDao _authorityDao;

        IAuthorityDao IDaoFactory.GetAuthorityDao()
        {
            if (this._authorityDao == null)
            {
                this._authorityDao = new AuthorityDao();
            }
            return this._authorityDao;
        }

        private ISubCategoryDao _subCategoryDao;

        ISubCategoryDao IDaoFactory.GetSubCategoryDao()
        {
            if (this._subCategoryDao == null)
            {
                this._subCategoryDao = new SubCategoryDao();
            }
            return this._subCategoryDao;
        }
    }
}
