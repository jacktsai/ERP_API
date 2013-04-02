using ErpApi.BLL;
using ErpApi.DAL;

namespace ErpApi.Utilities
{
    /// <summary>
    /// A service factory.
    /// </summary>
    public static class ServiceFactory
    {
        /// <summary>
        /// Gets the instance of <see cref="ErpApi.BLL.IUserService"/> interface.
        /// </summary>
        /// <returns>The instance of <see cref="ErpApi.BLL.IUserService"/> interface.</returns>
        public static IUserService GetUserService()
        {
            return new UserService()
            {
                UserDao = new UserDao(),
                SubCategoryDao = new SubCategoryDao(),
                RoleDao = new RoleDao(),
                PrivilegeDao = new PrivilegeDao(),
                DenyPrivilegeDao = new DenyPrivilegeDao(),
            };
        }

        /// <summary>
        /// Gets the instance of <see cref="ErpApi.BLL.ISubCategoryService"/> interface.
        /// </summary>
        /// <returns>The instance of <see cref="ErpApi.BLL.ISubCategoryService"/> interface.</returns>
        public static ISubCategoryService GetSubCategoryService()
        {
            return new SubCategoryService()
            {
                UserDao = new UserDao(),
                SubCategoryDao = new SubCategoryDao(),
            };
        }
    }
}