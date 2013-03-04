using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Yahoo.DataAccess;

namespace Yahoo.Business.Defaults
{
    public class DefaultBusinessFactory : IBusinessFactory
    {
        IUserDao userDao;

        IUserDao IBusinessFactory.GetUserDao()
        {
            if (userDao == null)
            {
                userDao = new Yahoo.DataAccess.Common.UserDao();
            }
            return userDao;
        }

        IRoleDao roleDao;

        IRoleDao IBusinessFactory.GetRoleDao()
        {
            if (roleDao == null)
            {
                roleDao = new Yahoo.DataAccess.Common.RoleDao();
            }
            return roleDao;
        }

        IPrivilegeDao privilegeDao;

        IPrivilegeDao IBusinessFactory.GetPrivilegeDao()
        {
            if (privilegeDao == null)
            {
                privilegeDao = new Yahoo.DataAccess.Common.PrivilegeDao();
            }
            return privilegeDao;
        }

        IAuthorityDao authorityDao;

        IAuthorityDao IBusinessFactory.GetAuthorityDao()
        {
            if (authorityDao == null)
            {
                authorityDao = new Yahoo.DataAccess.Common.AuthorityDao();
            }
            return authorityDao;
        }

        ISubCategoryDao subCategoryDao;

        ISubCategoryDao IBusinessFactory.GetSubCategoryDao()
        {
            if (subCategoryDao == null)
            {
                subCategoryDao = new Yahoo.DataAccess.Common.SubCategoryDao();
            }
            return subCategoryDao;
        }
    }
}
