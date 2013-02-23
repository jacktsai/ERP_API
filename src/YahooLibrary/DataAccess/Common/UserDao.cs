using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Yahoo.DataAccess.Common
{
    public class UserDao : CommonDao, IUserDao
    {
        public UserDao()
            : base("security")
        {
        }

        User IUserDao.GetOne(int? id, string name, string password)
        {
            throw new NotImplementedException();
        }

        void IUserDao.Remove(User o)
        {
            throw new NotImplementedException();
        }

        void IUserDao.Add(User o)
        {
            throw new NotImplementedException();
        }

        void IUserDao.Update(User o)
        {
            throw new NotImplementedException();
        }
    }
}
