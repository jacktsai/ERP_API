using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ErpApi.Services
{
    /// <summary>
    /// 子站資訊介面。
    /// </summary>
    public interface ISubCategoryService
    {
        /// <summary>
        /// 取得子站維護人員資訊。
        /// </summary>
        /// <param name="subCategoryIds">The sub category IDs。</param>
        /// <returns></returns>
        IEnumerable<SubCategoryUser> GetSubCategoryUsers(IEnumerable<int> subCategoryIds);
    }
}
