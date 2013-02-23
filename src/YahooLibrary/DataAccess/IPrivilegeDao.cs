using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Yahoo.DataAccess
{
    public interface IPrivilegeDao
    {
        IEnumerable<Privilege> GetMany(int? userId = null);

        void Remove(int privilegeId);
        void Add(Privilege o);
        void Update(Privilege o);
    }
}
