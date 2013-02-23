using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Yahoo.DataAccess;
using Yahoo.Business.Security.Cryptography;

namespace Yahoo.Business.Security
{
    /// <summary>
    /// 預設的 <see cref="IAuthenticationService"/> 介面實作。
    /// </summary>
    public class DefaultAuthenticationService : IAuthenticationService
    {
        private readonly IUserDao userDao;
        private readonly IHashProvider hashProvider;

        public DefaultAuthenticationService(IUserDao userDao,IHashProvider hashProvider)
        {
            this.userDao = userDao;
            this.hashProvider = hashProvider;
        }

        UserInfo IAuthenticationService.CreateUser(string userName, string password)
        {
            throw new NotImplementedException();
        }

        void IAuthenticationService.DeleteUser(int userId)
        {
            throw new NotImplementedException();
        }

        void IAuthenticationService.UpdateUser(UserInfo user)
        {
            throw new NotImplementedException();
        }

        UserInfo IAuthenticationService.Authenticate(string userName, string password)
        {
            throw new NotImplementedException();
        }
    }
}
