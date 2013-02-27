using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Yahoo.DataAccess
{
    public interface IRoleDao
    {
        IEnumerable<Role> GetMany(int? userId = null);
    }
}
