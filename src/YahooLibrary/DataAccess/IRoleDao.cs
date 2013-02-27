using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Yahoo.DataAccess
{
    public interface IRoleDao
    {
        IEnumerable<RoleData> GetMany(int? userId = null);
    }
}
