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

        IEnumerable<RoleData> IRoleDao.GetMany(int? userId)
        {
            return new RoleData[]
            {
                new RoleData { Id = 1, HasSelect = true },
                new RoleData { Id = 2, HasInsert = true },
                new RoleData { Id = 3, HasUpdate = true },
                new RoleData { Id = 4, HasDelete = false },
                new RoleData { Id = 5, HasParticular = null },
            };
        }
    }
}
