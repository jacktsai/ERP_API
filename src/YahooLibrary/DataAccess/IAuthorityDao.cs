using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Yahoo.DataAccess
{
    public interface IAuthorityDao
    {
        IEnumerable<AuthorityData> GetMany(int userId);
        AuthorityData GetOne(int userId, string url);
    }
}
