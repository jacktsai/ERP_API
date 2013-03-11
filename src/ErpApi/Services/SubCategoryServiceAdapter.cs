using System.Collections.Generic;
using ErpApi.DAL;
using ErpApi.Entities;

namespace ErpApi.BLL
{
    /// <summary>
    /// A service adapter of <see cref="ErpApi.BLL.ISubCategoryService"/> interface.
    /// </summary>
    internal class SubCategoryServiceAdapter : ISubCategoryService
    {
        /// <summary>
        /// The instance of <see cref="ISubCategoryService"/> interface.
        /// </summary>
        private readonly ISubCategoryService _inner;

        /// <summary>
        /// Initializes a new instance of the <see cref="SubCategoryServiceAdapter" /> class.
        /// </summary>
        public SubCategoryServiceAdapter()
        {
            this._inner = new SubCategoryService()
            {
                UserDao = new UserDao(),
                SubCategoryDao = new SubCategoryDao(),
            };
        }

        /// <summary>
        /// 取得子站維護人員資訊。
        /// </summary>
        /// <param name="subCategoryIds">多筆子站代碼。</param>
        /// <returns>
        /// 多筆子站維護人員資訊。
        /// </returns>
        IEnumerable<SubCategoryContactModel> ISubCategoryService.GetSubCategoryUsers(IEnumerable<int> subCategoryIds)
        {
            return this._inner.GetSubCategoryUsers(subCategoryIds);
        }
    }
}