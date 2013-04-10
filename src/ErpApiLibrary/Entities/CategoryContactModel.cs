using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ErpApi.Entities
{
    /// <summary>
    /// 子站維護人員資訊。
    /// </summary>
    public class CategoryContactModel
    {
        /// <summary>
        /// 取得子站代碼。
        /// </summary>
        public int Id { get; internal set; }

        /// <summary>
        /// 取得 PM 資料。
        /// </summary>
        public PriUser Pm { get; internal set; }

        /// <summary>
        /// 取得 PM 主管資料。
        /// </summary>
        public PriUser Manager { get; internal set; }

        /// <summary>
        /// 取得採購人資料。
        /// </summary>
        public PriUser Purchaser { get; internal set; }

        /// <summary>
        /// 取得採購主任資料。
        /// </summary>
        public PriUser Staff { get; internal set; }
    }
}
