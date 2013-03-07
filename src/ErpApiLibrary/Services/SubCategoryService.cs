using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ErpApi.Data;

namespace ErpApi.Services
{
    /// <summary>
    /// 介面 <see cref="ISubCategoryService"/> 的實作。
    /// </summary>
    public class SubCategoryService : ISubCategoryService
    {
        /// <summary>
        /// <see cref="ErpApi.Data.IDaoFactory"/> 的執行個體。
        /// </summary>
        private readonly IDaoFactory _factory;

        /// <summary>
        /// Initializes a new instance of the <see cref="SubCategoryService" /> class.
        /// </summary>
        /// <param name="factory"><see cref="ErpApi.Data.IDaoFactory"/> 的執行個體。</param>
        /// <exception cref="System.ArgumentNullException">factory</exception>
        public SubCategoryService(IDaoFactory factory)
        {
            if (factory == null)
            {
                throw new ArgumentNullException("factory");
            }

            this._factory = factory;
        }

        /// <summary>
        /// 取得子站維護人員資訊。
        /// </summary>
        /// <param name="subCategoryIds">多筆子站代碼。</param>
        /// <returns>
        /// 多筆子站維護人員資訊。
        /// </returns>
        IEnumerable<SubCategoryUser> ISubCategoryService.GetSubCategoryUsers(IEnumerable<int> subCategoryIds)
        {
            var subCatDao = this._factory.GetSubCategoryDao();
            var subCatDatas = subCatDao.GetMany(subCategoryIds);

            if (subCatDatas == null || subCatDatas.Count() == 0)
            {
                return new SubCategoryUser[0];
            }

            // 將各個 SubCategoryData 的所有使用者名稱濃縮成單一序列。
            var userNames = subCatDatas
                                .SelectMany(o => new string[] { o.PmName, o.ManagerName, o.PurchaserName, o.StaffName })
                                .Where(s => !string.IsNullOrEmpty(s)); // 去掉 null 或空白的名稱。

            var userDao = this._factory.GetUserDao();
            var userDatas = userDao.GetMany(userNames);

            if (userDatas == null || userDatas.Count() == 0)
            {
                return subCatDatas.Select(o => new SubCategoryUser
                {
                    Id = o.Id
                });
            }

            var users = userDatas.Select(o => new User(o));
            var userMap = users.ToDictionary(o => o.Name); // 將使用者資料轉成 Dictionary 介面方便快速搜尋。

            return subCatDatas.Select(o => this.CreateSubCategoryUser(o, userMap));
        }

        /// <summary>
        /// 建立 SubCategoryUser 個體。
        /// </summary>
        /// <param name="data">SubCategoryData 個體。</param>
        /// <param name="userMap">UserData 快查表。</param>
        /// <returns>SubCategoryUser 個體。</returns>
        private SubCategoryUser CreateSubCategoryUser(SubCategoryData data, Dictionary<string, User> userMap)
        {
            var subCategoryUser = new SubCategoryUser
            {
                Id = data.Id,
            };

            subCategoryUser.Pm = userMap.GetOrDefault(data.PmName);

            subCategoryUser.Manager = userMap.GetOrDefault(data.ManagerName);

            subCategoryUser.Purchaser = userMap.GetOrDefault(data.PurchaserName);

            subCategoryUser.Staff = userMap.GetOrDefault(data.StaffName);

            return subCategoryUser;
        }
    }
}
