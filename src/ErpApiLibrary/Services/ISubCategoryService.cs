using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ErpApi.Services
{
    /// <summary>
    /// 提供子站相關的服務介面。
    /// </summary>
    public interface ISubCategoryService
    {
        /// <summary>
        /// 取得子站維護人員資訊。
        /// </summary>
        /// <param name="subCategoryIds">多筆子站代碼。</param>
        /// <returns>多筆子站維護人員資訊。</returns>
        IEnumerable<SubCategoryUser> GetSubCategoryUsers(IEnumerable<int> subCategoryIds);
    }
}
