using System.Collections.Generic;
using ErpApi.Entities;

namespace ErpApi.BLL
{
    /// <summary>
    /// 提供子站相關的服務介面。
    /// </summary>
    public interface ICategoryService
    {
        /// <summary>
        /// 取得子站維護人員資訊。
        /// </summary>
        /// <param name="categoryIds">多筆子站代碼。</param>
        /// <returns>多筆子站維護人員資訊。</returns>
        IEnumerable<CategoryContactModel> GetCategoryContacts(IEnumerable<int> categoryIds);

        /// <summary>
        /// 取得子站相關資訊。
        /// </summary>
        /// <param name="categoryIds">多筆子站代碼。</param>
        /// <returns>多筆子站相關資訊。</returns>
        IEnumerable<CategoryModel> GetCategories(IEnumerable<int> categoryIds);
    }
}