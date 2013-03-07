using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ErpApi.Data
{
    /// <summary>
    /// 子站資料。
    /// </summary>
    public class SubCategoryData
    {
        /// <summary>
        /// 子站編號。
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// PM 姓名。
        /// </summary>
        public string PmName { get; set; }

        /// <summary>
        /// PM 主管姓名。
        /// </summary>
        public string ManagerName { get; set; }

        /// <summary>
        /// 採購人員姓名。
        /// </summary>
        public string PurchaserName { get; set; }

        /// <summary>
        /// 採購主管姓名。
        /// </summary>
        public string StaffName { get; set; }
    }
}
