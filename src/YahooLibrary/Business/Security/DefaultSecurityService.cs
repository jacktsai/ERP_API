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
        private readonly IRoleDao roleDao;
        private readonly IPrivilegeDao privilegeDao;
        private readonly IFunctionDao functionDao;
        private readonly IHashProvider hashProvider;

        public DefaultSecurityService(IUserDao userDao, IRoleDao roleDao, IPrivilegeDao privilegeDao, IFunctionDao functionDao, IHashProvider hashProvider)
        {
            if (userDao == null)
            {
                throw new ArgumentNullException("userDao");
            }
            if (roleDao == null)
            {
                throw new ArgumentNullException("roleDao");
            }
            if (privilegeDao == null)
            {
                throw new ArgumentNullException("privilegeDao");
            }
            if (functionDao == null)
            {
                throw new ArgumentNullException("functionDao");
            }
            if (hashProvider == null)
            {
                throw new ArgumentNullException("hashProvider");
            }

            this.userDao = userDao;
            this.roleDao = roleDao;
            this.privilegeDao = privilegeDao;
            this.functionDao = functionDao;
            this.hashProvider = hashProvider;
        }

        UserProfile ISecurityService.CreateUser(string userName, string password)
        {
            throw new NotImplementedException();
        }

        void ISecurityService.DeleteUser(int userId)
        {
            throw new NotImplementedException();
        }

        void ISecurityService.UpdateUser(UserProfile user)
        {
            throw new NotImplementedException();
        }

        UserProfile ISecurityService.Authenticate(string userName, string password)
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

        UserProfile ISecurityService.GetProfile(int userId)
        {
            var user = this.userDao.GetOne(id: userId);

            if (user == null)
            {
                return null;
            }

            var roles = this.roleDao.GetMany(userId: userId);

            PrivilegeInfo[] privilegeInfos = null;

            var privileges = this.privilegeDao.GetMany(userId: userId);
            if (privileges != null)
            {
                var functions = this.functionDao.GetMany(privileges.Select(o => o.FunctionId));
                if (functions != null)
                {
                    privilegeInfos =
                        (
                            from p in privileges
                            join f in functions on p.FunctionId equals f.Id
                            select new PrivilegeInfo
                            {
                                Id = p.Id,
                                FunctionId = f.Id,
                                CategoryId = f.CategoryId,
                                CategorySubId = f.CategorySubId
                            }
                        ).ToArray();
                }
            }

            return new UserProfile
            {
                Id = user.Id,
                Name = user.Name,
                FullName = user.FullName,
                Department = user.Department,
                Degree = user.Degree,
                Homepage = user.Homepage,
                ExtensionNumber = user.ExtensionNumber,
                BackyardId = user.BackyardId,
                PrivilegeInfos = privilegeInfos,

                HasSelect = roles != null ? roles.Any(o => o.HasSelect == true) : false,
                HasInsert = roles != null ? roles.Any(o => o.HasInsert == true) : false,
                HasUpdate = roles != null ? roles.Any(o => o.HasUpdate == true) : false,
                HasDelete = roles != null ? roles.Any(o => o.HasDelete == true) : false,
                HasParticular = roles != null ? roles.Any(o => o.HasParticular == true) : false,
            };
        }
    }
}
