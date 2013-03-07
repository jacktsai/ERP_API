﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ErpApi.Data
{
    /// <summary>
    /// 操作者資料存取介面。
    /// </summary>
    public interface IUserDao
    {
        /// <summary>
        /// 取得乙筆操作者資料。
        /// </summary>
        /// <param name="backyardId">Backyard ID。</param>
        /// <returns>操作者資料。</returns>
        UserData GetOne(string backyardId);

        /// <summary>
        /// 取得多筆操作者資料。
        /// </summary>
        /// <param name="userNames">多個使用者姓名。</param>
        /// <returns>多筆操作者資料。</returns>
        IEnumerable<UserData> GetMany(IEnumerable<string> userNames);
    }
}
