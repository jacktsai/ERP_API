using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ErpApi.Data;

namespace ErpApi.Data
{
    public interface IDaoFactory
    {
        IUserDao GetUserDao();

        IRoleDao GetRoleDao();

        IPrivilegeDao GetPrivilegeDao();

        IAuthorityDao GetAuthorityDao();

        ISubCategoryDao GetSubCategoryDao();
    }
}
