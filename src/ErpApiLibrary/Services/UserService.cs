using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ErpApi.Data;

namespace ErpApi.Services
{
    /// <summary>
    /// 介面 <see cref="IUserService"/> 的實作。
    /// </summary>
    public class UserService : IUserService
    {
        /// <summary>
        /// <see cref="ErpApi.Data.IDaoFactory"/> 的執行個體。
        /// </summary>
        private readonly IDaoFactory _factory;

        /// <summary>
        /// Initializes a new instance of the <see cref="UserService" /> class.
        /// </summary>
        /// <param name="factory"><see cref="ErpApi.Data.IDaoFactory"/> 的執行個體。</param>
        /// <exception cref="System.ArgumentNullException">factory</exception>
        public UserService(IDaoFactory factory)
        {
            if (factory == null)
            {
                throw new ArgumentNullException("factory");
            }

            this._factory = factory;
        }

        /// <summary>
        /// 取得使用者相關資訊。
        /// </summary>
        /// <param name="backyardId">The backyard id.</param>
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

            var userDao = this._factory.GetUserDao();
            var userData = userDao.GetOne(backyardId);

            if (userData == null)
            {
                return null;
            }

            var subCatDao = this._factory.GetSubCategoryDao();
            var subCats = subCatDao.GetMany(userData.Id);

            return new Profile
            {
                User = new User(userData),
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

            var privilegeDao = this._factory.GetPrivilegeDao();
            var privilegeData = privilegeDao.GetOne(backyardId, url);
            if (privilegeData != null)
            {
                authority.CanAccess = true;

                var roleDao = this._factory.GetRoleDao();
                var roleDatas = roleDao.GetMany(privilegeData.UserId, url);
                var denyDao = this._factory.GetDenyPrivilegeDao();
                var denyData = denyDao.GetOne(privilegeData.UserId, url);

                authority.CanSelect = this.Judge(roleDatas, r => r.CanSelect, denyData, d => d.DenySelect);
                authority.CanInsert = this.Judge(roleDatas, r => r.CanInsert, denyData, d => d.DenyInsert);
                authority.CanUpdate = this.Judge(roleDatas, r => r.CanUpdate, denyData, d => d.DenyUpdate);
                authority.CanDelete = this.Judge(roleDatas, r => r.CanDelete, denyData, d => d.DenyDelete);
                authority.CanParticular = this.Judge(roleDatas, r => r.CanParticular, denyData, d => d.DenyParticular);
            }

            return authority;
        }

        /// <summary>
        /// 權限判斷。
        /// </summary>
        /// <param name="roleDatas">多筆角色資料。</param>
        /// <param name="canGetter">取得 allow 欄位的方法。</param>
        /// <param name="denyData">拒絕權限資料。</param>
        /// <param name="denyGetter">取得 deny 欄位的方法。</param>
        /// <returns>
        /// 如果有權限則回傳 true；否則回傳 false。
        /// </returns>
        private bool Judge(IEnumerable<RoleData> roleDatas, Func<RoleData, bool?> canGetter, DenyPrivilegeData denyData, Func<DenyPrivilegeData, bool> denyGetter)
        {
            // is denied ?
            if (denyData != null && denyGetter(denyData))
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
