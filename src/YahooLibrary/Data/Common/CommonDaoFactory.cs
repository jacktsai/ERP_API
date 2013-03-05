using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Yahoo.Data;

namespace Yahoo.Data.Common
{
    public class CommonDaoFactory : IDaoFactory
    {
        IUserDao userDao;

        IUserDao IDaoFactory.GetUserDao()
        {
            if (userDao == null)
            {
                userDao = new Yahoo.Data.Common.UserDao();
            }
            return userDao;
        }

        IRoleDao roleDao;

        IRoleDao IDaoFactory.GetRoleDao()
        {
            if (roleDao == null)
            {
                roleDao = new Yahoo.Data.Common.RoleDao();
            }
            return roleDao;
        }

        IPrivilegeDao privilegeDao;

        IPrivilegeDao IDaoFactory.GetPrivilegeDao()
        {
            if (privilegeDao == null)
            {
                privilegeDao = new Yahoo.Data.Common.PrivilegeDao();
            }
            return privilegeDao;
        }

        IAuthorityDao authorityDao;

        IAuthorityDao IDaoFactory.GetAuthorityDao()
        {
            if (authorityDao == null)
            {
                authorityDao = new Yahoo.Data.Common.AuthorityDao();
            }
            return authorityDao;
        }

        ISubCategoryDao subCategoryDao;

        ISubCategoryDao IDaoFactory.GetSubCategoryDao()
        {
            if (subCategoryDao == null)
            {
                subCategoryDao = new Yahoo.Data.Common.SubCategoryDao();
            }
            return subCategoryDao;
        }
    }
}
