using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Yahoo.DataAccess;

namespace Yahoo.Business
{
    public interface IBusinessFactory
    {
        IUserDao GetUserDao();
        IAuthorityDao GetAuthorityDao();
    }
}
