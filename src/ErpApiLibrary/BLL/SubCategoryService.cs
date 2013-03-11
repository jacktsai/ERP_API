using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ErpApi.DAL;
using ErpApi.Entities;

namespace ErpApi.BLL
{
    /// <summary>
    /// 介面 <see cref="ISubCategoryService"/> 的實作。
    /// </summary>
    public class SubCategoryService : ISubCategoryService
    {
        /// <summary>
        /// Gets or sets the <see cref="ErpApi.DAL.IUserDao"/> instance.
        /// </summary>
        /// <value>
        /// The <see cref="ErpApi.DAL.IUserDao"/> instance.
        /// </value>
        public IUserDao UserDao { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="ErpApi.DAL.ISubCategoryDao"/> instance.
        /// </summary>
        /// <value>
        /// The <see cref="ErpApi.DAL.ISubCategoryDao"/> instance.
        /// </value>
        public ISubCategoryDao SubCategoryDao { get; set; }

        /// <summary>
        /// 取得子站維護人員資訊。
        /// </summary>
        /// <param name="subCategoryIds">多筆子站代碼。</param>
        /// <returns>
        /// 多筆子站維護人員資訊。
        /// </returns>
        IEnumerable<SubCategoryContactModel> ISubCategoryService.GetSubCategoryUsers(IEnumerable<int> subCategoryIds)
        {
            var subCats = this.SubCategoryDao.GetMany(subCategoryIds);

            if (subCats == null || subCats.Count() == 0)
            {
                return new SubCategoryContactModel[0];
            }

            // 將各個 SubCategoryData 的所有使用者名稱濃縮成單一序列。
            var userNames = subCats
                                .SelectMany(o => new string[] { o.User.catsubusr_usrname, o.catsub_mdypm, o.catsub_mdypurher, o.catsub_mdystaff })
                                .Where(s => !string.IsNullOrEmpty(s)); // 去掉 null 或空白的名稱。

            var users = this.UserDao.GetMany(userNames);

            if (users == null || users.Count() == 0)
            {
                return subCats.Select(o => new SubCategoryContactModel
                {
                    Id = o.catsub_id
                });
            }

            var userMap = users.ToDictionary(o => o.priuser_name); // 將使用者資料轉成 Dictionary 介面方便快速搜尋。

            return subCats.Select(o => this.CreateSubCategoryContact(o, userMap));
        }

        /// <summary>
        /// 建立 SubCategoryUser 個體。
        /// </summary>
        /// <param name="subCat">SubCategoryData 個體。</param>
        /// <param name="userMap">User 快查表。</param>
        /// <returns>SubCategoryUser 個體。</returns>
        private SubCategoryContactModel CreateSubCategoryContact(SubCategory subCat, Dictionary<string, User> userMap)
        {
            var subCategoryUser = new SubCategoryContactModel
            {
                Id = subCat.catsub_id,
            };

            subCategoryUser.Pm = userMap.GetOrDefault(subCat.User.catsubusr_usrname);

            subCategoryUser.Manager = userMap.GetOrDefault(subCat.catsub_mdypm);

            subCategoryUser.Purchaser = userMap.GetOrDefault(subCat.catsub_mdypurher);

            subCategoryUser.Staff = userMap.GetOrDefault(subCat.catsub_mdystaff);

            return subCategoryUser;
        }
    }
}
