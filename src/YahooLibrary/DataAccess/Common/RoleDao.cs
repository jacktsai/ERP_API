using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Yahoo.DataAccess.Common
{
    public class RoleDao : CommonDao, IRoleDao
    {
        public RoleDao()
            : base("security")
        {
        }

        IEnumerable<Role> IRoleDao.GetMany(int? userId)
        {
            return new Role[]
            {
                new Role { Id = 1, HasSelect = true },
                new Role { Id = 2, HasInsert = true },
                new Role { Id = 3, HasUpdate = true },
                new Role { Id = 4, HasDelete = false },
                new Role { Id = 5, HasParticular = null },
            };
        }
    }
}
