using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Yahoo.DataAccess;
using Yahoo.Business.Security.Cryptography;

namespace Yahoo.Business.Security
{
    /// <summary>
    /// 預設的 <see cref="ISecurityService"/> 實作。
    /// </summary>
    public class DefaultSecurityService : ISecurityService
    {
        private readonly IUserDao userDao;
        private readonly IPrivilegeDao privilegeDao;
        private readonly IHashProvider hashProvider;

        public DefaultSecurityService(IUserDao userDao, IPrivilegeDao privilegeDao, IHashProvider hashProvider)
        {
            if (userDao == null)
            {
                throw new ArgumentNullException("userDao");
            }
            if (privilegeDao == null)
            {
                throw new ArgumentNullException("privilegeDao");
            }
            if (hashProvider == null)
            {
                throw new ArgumentNullException("hashProvider");
            }

            this.userDao = userDao;
            this.privilegeDao = privilegeDao;
            this.hashProvider = hashProvider;
        }

        UserInfo ISecurityService.CreateUser(string userName, string password)
        {
            throw new NotImplementedException();
        }

        void ISecurityService.DeleteUser(int userId)
        {
            throw new NotImplementedException();
        }

        void ISecurityService.UpdateUser(UserInfo user)
        {
            throw new NotImplementedException();
        }

        UserInfo ISecurityService.Authenticate(string userName, string password)
        {
            throw new NotImplementedException();
        }

        void ISecurityService.Authorize(int userId, int privilegeId)
        {
            throw new NotImplementedException();
        }

        void ISecurityService.Unauthorize(int userId, int privilegeId)
        {
            throw new NotImplementedException();
        }

        IEnumerable<PrivilegeInfo> ISecurityService.GetPrivileges(int userId)
        {
            return this.privilegeDao.GetMany(userId: userId)
                .Select(o => new PrivilegeInfo
                {
                    Id = o.Id
                });
        }
    }
}
