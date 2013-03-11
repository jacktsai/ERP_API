using ErpApi.DAL;
using ErpApi.Entities;

namespace ErpApi.BLL
{
    /// <summary>
    /// A service adapter of <see cref="ErpApi.BLL.IUserService"/> interface.
    /// </summary>
    internal class UserServiceAdapter : IUserService
    {
        /// <summary>
        /// The instance of <see cref="UserServiceAdapter"/> interface.
        /// </summary>
        private readonly IUserService _inner;

        /// <summary>
        /// Initializes a new instance of the <see cref="UserServiceAdapter" /> class.
        /// </summary>
        public UserServiceAdapter()
        {
            this._inner = new UserService()
            {
                UserDao = new UserDao(),
                SubCategoryDao = new SubCategoryDao(),
                RoleDao = new RoleDao(),
                PrivilegeDao = new PrivilegeDao(),
                DenyPrivilegeDao = new DenyPrivilegeDao(),
            };
        }

        /// <summary>
        /// 取得使用者相關資訊。
        /// </summary>
        /// <param name="backyardId">The backyard id.</param>
        /// <returns>
        /// 使用者相關資訊。
        /// </returns>
        Profile IUserService.GetProfile(string backyardId)
        {
            return this._inner.GetProfile(backyardId);
        }

        /// <summary>
        /// 取得使用者 URL 的權限資訊。
        /// </summary>
        /// <param name="backyardId">The backyard id.</param>
        /// <param name="url">The URL.</param>
        /// <returns>
        /// 使用者 URL 的權限資訊。
        /// </returns>
        Authority IUserService.GetAuthority(string backyardId, string url)
        {
            return this._inner.GetAuthority(backyardId, url);
        }
    }
}