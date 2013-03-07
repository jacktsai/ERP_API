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
        /// 取得操作者相關資訊。
        /// </summary>
        /// <param name="backyardId">The backyard id.</param>
        /// <returns>
        /// 操作者相關資訊。
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
        /// 取得操作者 URL 的權限資訊。
        /// </summary>
        /// <param name="backyardId">The backyard id.</param>
        /// <param name="url">The URL.</param>
        /// <returns>
        /// 操作者 URL 的權限資訊。
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

            var dao = this._factory.GetAuthorityDao();
            var data = dao.GetOne(backyardId, url);

            var authority = new Authority();

            if (data == null)
            {
                return authority;
            }

            authority.CanAccess = true;

            authority.CanSelect = this.Judge(data, d => d.CanSelect, d => d.DenySelect);
            authority.CanInsert = this.Judge(data, d => d.CanInsert, d => d.DenyInsert);
            authority.CanUpdate = this.Judge(data, d => d.CanUpdate, d => d.DenyUpdate);
            authority.CanDelete = this.Judge(data, d => d.CanDelete, d => d.DenyDelete);
            authority.CanParticular = this.Judge(data, d => d.CanParticular, d => d.DenyParticular);

            return authority;
        }

        /// <summary>
        /// 權限判斷。
        /// </summary>
        /// <param name="data">AuthorityData。</param>
        /// <param name="canGetter">取得 allow 欄位的方法。</param>
        /// <param name="denyGetter">取得 deny 欄位的方法。</param>
        /// <returns>
        /// 如果有權限則回傳 true；否則回傳 false。
        /// </returns>
        private bool Judge(AuthorityData data, Func<AuthorityData, bool> canGetter, Func<AuthorityData, bool> denyGetter)
        {
            // is denied ?
            if (denyGetter(data))
            {
                return false;
            }

            // is granted ?
            if (canGetter(data))
            {
                return true;
            }

            // default is false.
            return false;
        }
    }
}
