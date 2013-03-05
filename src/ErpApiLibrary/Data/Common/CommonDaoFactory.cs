using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ErpApi.Data;

namespace ErpApi.Data.Common
{
    public class CommonDaoFactory : IDaoFactory
    {
        IUserDao userDao;

        IUserDao IDaoFactory.GetUserDao()
        {
            if (userDao == null)
            {
                userDao = new ErpApi.Data.Common.UserDao();
            }
            return userDao;
        }

        IRoleDao roleDao;

        IRoleDao IDaoFactory.GetRoleDao()
        {
            if (roleDao == null)
            {
                roleDao = new ErpApi.Data.Common.RoleDao();
            }
            return roleDao;
        }

        IPrivilegeDao privilegeDao;

        IPrivilegeDao IDaoFactory.GetPrivilegeDao()
        {
            if (privilegeDao == null)
            {
                privilegeDao = new ErpApi.Data.Common.PrivilegeDao();
            }
            return privilegeDao;
        }

        IAuthorityDao authorityDao;

        IAuthorityDao IDaoFactory.GetAuthorityDao()
        {
            if (authorityDao == null)
            {
                authorityDao = new ErpApi.Data.Common.AuthorityDao();
            }
            return authorityDao;
        }

        ISubCategoryDao subCategoryDao;

        ISubCategoryDao IDaoFactory.GetSubCategoryDao()
        {
            if (subCategoryDao == null)
            {
                subCategoryDao = new ErpApi.Data.Common.SubCategoryDao();
            }
            return subCategoryDao;
        }
    }
}
