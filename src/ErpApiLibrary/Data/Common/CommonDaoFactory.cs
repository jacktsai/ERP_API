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
        /// 授權資料存取介面。
        /// </summary>
        private IAuthorityDao _authorityDao;

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
        /// 取得授權資料存取介面。
        /// </summary>
        /// <returns>
        /// 授權資料存取介面。
        /// </returns>
        IAuthorityDao IDaoFactory.GetAuthorityDao()
        {
            if (this._authorityDao == null)
            {
                this._authorityDao = new AuthorityDao();
            }

            return this._authorityDao;
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