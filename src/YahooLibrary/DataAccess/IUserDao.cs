using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Yahoo.DataAccess
{
    public interface IUserDao
    {
        User GetOne(int? id = null, string name = null, string password = null);

        void Remove(User o);
        void Add(User o);
        void Update(User o);
    }
}
