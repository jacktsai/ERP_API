using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Yahoo.DataAccess;

namespace Yahoo.Business
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

        IAuthorityDao authorityDao;

        IAuthorityDao IBusinessFactory.GetAuthorityDao()
        {
            if (authorityDao == null)
            {
                authorityDao = new Yahoo.DataAccess.Common.AuthorityDao();
            }
            return authorityDao;
        }
    }
}
