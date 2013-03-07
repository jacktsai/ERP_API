namespace ErpApi.Data.Common
{
    /// <summary>
    /// 介面 <see cref="IDaoFactory"/> 的實作類別。
    /// 此類別提供以 System.Data.Common 為基礎的資料存取架構。
    /// </summary>
    public class CommonDaoFactory : IDaoFactory
    {
        /// <summary>
        /// 使用者資料存取介面。
        /// </summary>
        private IUserDao _userDao;

        /// <summary>
        /// 角色資料存取介面。
        /// </summary>
        private IRoleDao _roleDao;

        /// <summary>
        /// 使用者功能授權資料存取介面。
        /// </summary>
        private IPrivilegeDao _privilegeDao;

        /// <summary>
        /// 拒絕權限資料存取介面。
        /// </summary>
        private IDenyPrivilegeDao _denyPrivilegeDao;

        /// <summary>
        /// 子站資料存取介面。
        /// </summary>
        private ISubCategoryDao _subCategoryDao;

        /// <summary>
        /// 取得使用者資料存取介面。
        /// </summary>
        /// <returns>
        /// 使用者資料存取介面。
        /// </returns>
        IUserDao IDaoFactory.GetUserDao()
        {
            if (this._userDao == null)
            {
                this._userDao = new UserDao();
            }

            return this._userDao;
        }

        /// <summary>
        /// 取得角色資料存取介面。
        /// </summary>
        /// <returns>
        /// 角色資料存取介面。
        /// </returns>
        IRoleDao IDaoFactory.GetRoleDao()
        {
            if (this._roleDao == null)
            {
                this._roleDao = new RoleDao();
            }

            return this._roleDao;
        }

        /// <summary>
        /// 取得使用者功能授權資料存取介面。
        /// </summary>
        /// <returns>
        /// 使用者功能授權資料存取介面。
        /// </returns>
        IPrivilegeDao IDaoFactory.GetPrivilegeDao()
        {
            if (this._privilegeDao == null)
            {
                this._privilegeDao = new PrivilegeDao();
            }

            return this._privilegeDao;
        }

        /// <summary>
        /// 取得拒絕權限資料存取介面。
        /// </summary>
        /// <returns>
        /// 拒絕權限資料存取介面。
        /// </returns>
        IDenyPrivilegeDao IDaoFactory.GetDenyPrivilegeDao()
        {
            if (this._denyPrivilegeDao == null)
            {
                this._denyPrivilegeDao = new DenyPrivilegeDao();
            }

            return this._denyPrivilegeDao;
        }

        /// <summary>
        /// 取得子站資料存取介面。
        /// </summary>
        /// <returns>
        /// 子站資料存取介面。
        /// </returns>
        ISubCategoryDao IDaoFactory.GetSubCategoryDao()
        {
            if (this._subCategoryDao == null)
            {
                this._subCategoryDao = new SubCategoryDao();
            }

            return this._subCategoryDao;
        }
    }
}