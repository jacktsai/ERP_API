using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ErpApi.Data;

namespace ErpApi.Services
{
    public class SubCategoryService : ISubCategoryService
    {
        private readonly IDaoFactory _factory;

        public SubCategoryService(IDaoFactory factory)
        {
            if (factory == null)
            {
                throw new ArgumentNullException("factory");
            }

            this._factory = factory;
        }

        IEnumerable<SubCategoryUser> ISubCategoryService.GetSubCategoryUsers(IEnumerable<int> subCategoryIds)
        {
            var subCatDao = this._factory.GetSubCategoryDao();
            var subCatDatas = subCatDao.GetMany(subCategoryIds);

            if (subCatDatas == null || subCatDatas.Count() == 0)
            {
                return new SubCategoryUser[0];
            }

            //將各個 SubCategoryData 的所有使用者名稱濃縮成單一序列。
            var userNames = subCatDatas
                                .SelectMany(o => new string[] { o.PmName, o.ManagerName, o.PurchaserName, o.StaffName })
                                .Where(s => !string.IsNullOrEmpty(s)); //去掉 null 或空白的名稱。

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
            var userMap = users.ToDictionary(o => o.Name); //將使用者資料轉成 Dictionary 介面方便快速搜尋。

            return subCatDatas.Select(o => CreateSubCategoryUser(o, userMap));
        }

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
