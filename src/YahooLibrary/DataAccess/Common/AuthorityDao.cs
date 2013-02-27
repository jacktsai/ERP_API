using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Yahoo.DataAccess.Common
{
    public class AuthorityDao : CommonDao, IAuthorityDao
    {
        public AuthorityDao()
            : base("security")
        {
        }

        IEnumerable<AuthorityData> IAuthorityDao.GetMany(int userId)
        {
            throw new NotImplementedException();
        }

        AuthorityData IAuthorityDao.GetOne(int userId, string url)
        {
            throw new NotImplementedException();
        }
    }
}
