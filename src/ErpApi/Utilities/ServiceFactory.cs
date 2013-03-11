using ErpApi.BLL;

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
            return new UserServiceAdapter();
        }

        /// <summary>
        /// Gets the instance of <see cref="ErpApi.BLL.ISubCategoryService"/> interface.
        /// </summary>
        /// <returns>The instance of <see cref="ErpApi.BLL.ISubCategoryService"/> interface.</returns>
        public static ISubCategoryService GetSubCategoryService()
        {
            return new SubCategoryServiceAdapter();
        }
    }
}