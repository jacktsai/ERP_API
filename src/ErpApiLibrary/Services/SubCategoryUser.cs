using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ErpApi.Services
{
    /// <summary>
    /// 子站維護人員資訊。
    /// </summary>
    public class SubCategoryUser
    {
        /// <summary>
        /// 取得子站代碼。
        /// </summary>
        public int Id { get; internal set; }

        /// <summary>
        /// 取得 PM 資料。
        /// </summary>
        public User Pm { get; internal set; }

        /// <summary>
        /// 取得 PM 主管資料。
        /// </summary>
        public User Manager { get; internal set; }

        /// <summary>
        /// 取得採購人資料。
        /// </summary>
        public User Purchaser { get; internal set; }

        /// <summary>
        /// 取得採購主任資料。
        /// </summary>
        public User Staff { get; internal set; }
    }
}
