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
        /// Gets or sets the <see cref="ErpApi.DAL.IUserDao"/> instance.
        /// </summary>
        /// <value>
        /// The <see cref="ErpApi.DAL.IUserDao"/> instance.
        /// </value>
        public IUserDao UserDao { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="ErpApi.DAL.IRoleDao"/> instance.
        /// </summary>
        /// <value>
        /// The <see cref="ErpApi.DAL.IRoleDao"/> instance.
        /// </value>
        public IRoleDao RoleDao { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="ErpApi.DAL.ISubCategoryDao"/> instance.
        /// </summary>
        /// <value>
        /// The <see cref="ErpApi.DAL.ISubCategoryDao"/> instance.
        /// </value>
        public ISubCategoryDao SubCategoryDao { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="ErpApi.DAL.IPrivilegeDao"/> instance.
        /// </summary>
        /// <value>
        /// The <see cref="ErpApi.DAL.IPrivilegeDao"/> instance.
        /// </value>
        public IPrivilegeDao PrivilegeDao { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="ErpApi.DAL.IDenyPrivilegeDao"/> instance.
        /// </summary>
        /// <value>
        /// The <see cref="ErpApi.DAL.IDenyPrivilegeDao"/> instance.
        /// </value>
        public IDenyPrivilegeDao DenyPrivilegeDao { get; set; }

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

            var user = this.UserDao.GetOne(backyardId);

            if (user == null)
            {
                return null;
            }

            var subCats = this.SubCategoryDao.GetMany(user.priuser_id);

            return new Profile
            {
                User = user,
                SubCatIds = subCats.Select(o => o.catsub_id),
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

                var roleDatas = this.RoleDao.GetMany(privilege.privilege_priuserid, url);
                var denyData = this.DenyPrivilegeDao.GetOne(privilege.privilege_priuserid, url);

                authority.CanSelect = this.Judge(roleDatas, r => r.roles_select, denyData, d => d.denyprivs_select);
                authority.CanInsert = this.Judge(roleDatas, r => r.roles_insert, denyData, d => d.denyprivs_insert);
                authority.CanUpdate = this.Judge(roleDatas, r => r.roles_update, denyData, d => d.denyprivs_update);
                authority.CanDelete = this.Judge(roleDatas, r => r.roles_delete, denyData, d => d.denyprivs_delete);
                authority.CanParticular = this.Judge(roleDatas, r => r.roles_particular, denyData, d => d.denyprivs_particular);
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
        private bool Judge(IEnumerable<Role> roleDatas, Func<Role, bool?> canGetter, DenyPrivilege denyPriv, Func<DenyPrivilege, bool> denyGetter)
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