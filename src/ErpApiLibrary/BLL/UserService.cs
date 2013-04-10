using System;
using System.Collections.Generic;
using System.Linq;
using ErpApi.DAL;
using ErpApi.Entities;

namespace ErpApi.BLL
{
    /// <summary>
    /// 介面 <see cref="IUserService"/> 的實作。
    /// </summary>
    public class UserService : IUserService
    {
        /// <summary>
        /// Gets or sets the <see cref="ErpApi.DAL.IPriUserDao"/> instance.
        /// </summary>
        /// <value>
        /// The <see cref="ErpApi.DAL.IPriUserDao"/> instance.
        /// </value>
        public IPriUserDao PriUserDao { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="ErpApi.DAL.IRoleDao"/> instance.
        /// </summary>
        /// <value>
        /// The <see cref="ErpApi.DAL.IRoleDao"/> instance.
        /// </value>
        public IRoleDao RoleDao { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="ErpApi.DAL.ICatSubDao"/> instance.
        /// </summary>
        /// <value>
        /// The <see cref="ErpApi.DAL.ICatSubDao"/> instance.
        /// </value>
        public ICatSubDao CatSubDao { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="ErpApi.DAL.IPrivilegeDao"/> instance.
        /// </summary>
        /// <value>
        /// The <see cref="ErpApi.DAL.IPrivilegeDao"/> instance.
        /// </value>
        public IPrivilegeDao PrivilegeDao { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="ErpApi.DAL.IDenyPrivDao"/> instance.
        /// </summary>
        /// <value>
        /// The <see cref="ErpApi.DAL.IDenyPrivDao"/> instance.
        /// </value>
        public IDenyPrivDao DenyPrivDao { get; set; }

        /// <summary>
        /// 取得使用者相關資訊。
        /// </summary>
        /// <param name="backyardId">Backyard ID。</param>
        /// <returns>
        /// 使用者相關資訊。
        /// </returns>
        /// <exception cref="System.ArgumentNullException">backyardId</exception>
        Profile IUserService.GetProfile(string backyardId)
        {
            if (backyardId == null)
            {
                throw new ArgumentNullException("backyardId");
            }

            var user = this.PriUserDao.GetOne(backyardId);

            if (user == null)
            {
                return null;
            }

            var subCats = this.CatSubDao.GetMany(user.Id);

            return new Profile
            {
                User = user,
                SubCatIds = subCats.Select(o => o.Id),
            };
        }

        /// <summary>
        /// 取得使用者 URL 的權限資訊。
        /// </summary>
        /// <param name="backyardId">The backyard id.</param>
        /// <param name="url">The URL.</param>
        /// <returns>
        /// 使用者 URL 的權限資訊。
        /// </returns>
        /// <exception cref="System.ArgumentNullException">backyardId</exception>
        Authority IUserService.GetAuthority(string backyardId, string url)
        {
            if (backyardId == null)
            {
                throw new ArgumentNullException("backyardId");
            }

            if (url == null)
            {
                throw new ArgumentNullException("url");
            }

            var authority = new Authority();

            var privilege = this.PrivilegeDao.GetOne(backyardId, url);
            if (privilege != null)
            {
                authority.CanAccess = true;

                var roleDatas = this.RoleDao.GetMany(privilege.PriUserId, url);
                var denyData = this.DenyPrivDao.GetOne(privilege.PriUserId, url);

                authority.CanSelect = this.Judge(roleDatas, r => r.Select, denyData, d => d.Select);
                authority.CanInsert = this.Judge(roleDatas, r => r.Insert, denyData, d => d.Insert);
                authority.CanUpdate = this.Judge(roleDatas, r => r.Update, denyData, d => d.Update);
                authority.CanDelete = this.Judge(roleDatas, r => r.Delete, denyData, d => d.Delete);
                authority.CanParticular = this.Judge(roleDatas, r => r.Particular, denyData, d => d.Particular);
            }

            return authority;
        }

        /// <summary>
        /// 權限判斷。
        /// </summary>
        /// <param name="roleDatas">多筆角色資料。</param>
        /// <param name="canGetter">取得 allow 欄位的方法。</param>
        /// <param name="denyPriv">拒絕權限資料。</param>
        /// <param name="denyGetter">取得 deny 欄位的方法。</param>
        /// <returns>
        /// 如果有權限則回傳 true；否則回傳 false。
        /// </returns>
        private bool Judge(IEnumerable<Role> roleDatas, Func<Role, bool?> canGetter, DenyPriv denyPriv, Func<DenyPriv, bool> denyGetter)
        {
            // is denied ?
            if (denyPriv != null && denyGetter(denyPriv))
            {
                return false;
            }

            // is granted ?
            if (roleDatas != null && roleDatas.Any(r => canGetter(r) == true))
            {
                return true;
            }

            // default is false.
            return false;
        }
    }
}