using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Yahoo.Business.Security.Cryptography;
using Yahoo.DataAccess;

namespace Yahoo.Business.Security
{
    /// <summary>
    /// 預設的 <see cref="IAuthorizationService"/> 介面實作。
    /// </summary>
    public class DefaultAuthorizationService : IAuthorizationService
    {
        private readonly IPrivilegeDao privilegeDao;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="hashProvider"></param>
        /// <param name="securityDao"></param>
        public DefaultAuthorizationService(IPrivilegeDao privilegeDao)
        {
            this.privilegeDao = privilegeDao;
        }

        void IAuthorizationService.Authorize(int userId, int privilegeId)
        {
            throw new NotImplementedException();
        }

        void IAuthorizationService.Unauthorize(int userId, int privilegeId)
        {
            throw new NotImplementedException();
        }

        IEnumerable<PrivilegeInfo> IAuthorizationService.GetPrivileges(int userId)
        {
            return this.privilegeDao.GetMany(userId: userId)
                .Select(o => new PrivilegeInfo
                {
                    Id = o.Id
                });
        }
    }
}
