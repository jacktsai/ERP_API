using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ErpApi.DAL;
using ErpApi.Entities;

namespace ErpApi.BLL
{
    /// <summary>
    /// 介面 <see cref="ICategoryService"/> 的實作。
    /// </summary>
    public class CategoryService : ICategoryService
    {
        /// <summary>
        /// Gets or sets the <see cref="ErpApi.DAL.IPriUserDao"/> instance.
        /// </summary>
        /// <value>
        /// The <see cref="ErpApi.DAL.IPriUserDao"/> instance.
        /// </value>
        public IPriUserDao PriUserDao { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="ErpApi.DAL.ICatSubDao"/> instance.
        /// </summary>
        /// <value>
        /// The <see cref="ErpApi.DAL.ICatSubDao"/> instance.
        /// </value>
        public ICatSubDao CatSubDao { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="ErpApi.DAL.ICatZoneDao"/> instance.
        /// </summary>
        /// <value>
        /// The <see cref="ErpApi.DAL.ICatZoneDao"/> instance.
        /// </value>
        public ICatZoneDao CatZoneDao { get; set; }

        /// <summary>
        /// 取得子站維護人員資訊。
        /// </summary>
        /// <param name="categoryIds">多筆子站代碼。</param>
        /// <returns>
        /// 多筆子站維護人員資訊。
        /// </returns>
        IEnumerable<CategoryContactModel> ICategoryService.GetCategoryContacts(IEnumerable<int> categoryIds)
        {
            var catSubs = this.CatSubDao.GetMany(categoryIds);

            if (catSubs == null || !catSubs.Any())
            {
                return new CategoryContactModel[0];
            }

            // 將各個 SubCategoryData 的所有使用者名稱濃縮成單一序列。
            var userNames = catSubs
                                .SelectMany(o => new string[] { o.User.UsrName, o.MdyPm, o.MdyPurher, o.MdyStaff })
                                .Where(s => !string.IsNullOrEmpty(s)); // 去掉 null 或空白的名稱。

            var users = this.PriUserDao.GetMany(userNames);

            if (users == null || !users.Any())
            {
                return catSubs.Select(o => new CategoryContactModel
                {
                    Id = o.Id
                });
            }

            var userMap = users.ToDictionary(o => o.Name); // 將使用者資料轉成 Dictionary 介面方便快速搜尋。

            return catSubs.Select(o => this.CreateCategoryContact(o, userMap));
        }

        /// <summary>
        /// 取得子站相關資訊。
        /// </summary>
        /// <param name="categoryIds">多筆子站代碼。</param>
        /// <returns>
        /// 多筆子站相關資訊。
        /// </returns>
        IEnumerable<CategoryModel> ICategoryService.GetCategories(IEnumerable<int> categoryIds)
        {
            var catSubs = this.CatSubDao.GetMany(categoryIds);

            if (catSubs == null || !catSubs.Any())
            {
                return new CategoryModel[0];
            }

            var catZones = this.CatZoneDao.GetMany(catSubs.Select(o => o.ZoneId));

            return catSubs.Join(
                catZones,
                catSub => catSub.ZoneId,
                catZone => catZone.Id,
                (catSub, catZone) => new CategoryModel
                {
                    CatSub = catSub,
                    CatZone = catZone,
                });
        }

        /// <summary>
        /// 建立 SubCategoryUser 個體。
        /// </summary>
        /// <param name="catSub">CatSub 個體</param>
        /// <param name="userMap">User 快查表。</param>
        /// <returns>子站維護人員資訊</returns>
        private CategoryContactModel CreateCategoryContact(CatSub catSub, Dictionary<string, PriUser> userMap)
        {
            var categoryContact = new CategoryContactModel
            {
                Id = catSub.Id,
            };

            categoryContact.Pm = userMap.GetOrDefault(catSub.User.UsrName);

            categoryContact.Manager = userMap.GetOrDefault(catSub.MdyPm);

            categoryContact.Purchaser = userMap.GetOrDefault(catSub.MdyPurher);

            categoryContact.Staff = userMap.GetOrDefault(catSub.MdyStaff);

            return categoryContact;
        }
    }
}
