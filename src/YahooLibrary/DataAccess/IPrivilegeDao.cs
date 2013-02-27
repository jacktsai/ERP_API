using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Yahoo.DataAccess
{
    public interface IPrivilegeDao
    {
        IEnumerable<PrivilegeData> GetMany(int? userId = null);

        void Remove(int privilegeId);
        void Add(PrivilegeData o);
        void Update(PrivilegeData o);
    }
}
