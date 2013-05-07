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
            return new UserService
            {
                PriUserDao = new PriUserDao(),
                CatSubDao = new CatSubDao(),
                RoleDao = new RoleDao(),
                PrivilegeDao = new PrivilegeDao(),
                DenyPrivDao = new DenyPrivDao(),
            };
        }

        /// <summary>
        /// Gets the instance of <see cref="ErpApi.BLL.ICategoryService"/> interface.
        /// </summary>
        /// <returns>The instance of <see cref="ErpApi.BLL.ICategoryService"/> interface.</returns>
        public static ICategoryService GetSubCategoryService()
        {
            return new CategoryService
            {
                PriUserDao = new PriUserDao(),
                CatSubDao = new CatSubDao(),
                CatZoneDao = new CatZoneDao(),
            };
        }

        /// <summary>
        /// Gets the instance of <see cref="ErpApi.BLL.IProductService"/> interface.
        /// </summary>
        /// <returns>The instance of <see cref="ErpApi.BLL.IProductService"/> interface.</returns>
        public static IProductService GetProductService()
        {
            return new ProductService
            {
                ProductDao = new ProductDao(),
            };
        }
    }
}