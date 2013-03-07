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
        /// 取得或設定子站編號。
        /// </summary>
        /// <value>
        /// 子站編號。
        /// </value>
        public int Id { get; set; }

        /// <summary>
        /// 取得或設定 PM 姓名。
        /// </summary>
        /// <value>
        /// PM 姓名。
        /// </value>
        public string PmName { get; set; }

        /// <summary>
        /// 取得或設定 PM 主管姓名。
        /// </summary>
        /// <value>
        /// PM 主管姓名。
        /// </value>
        public string ManagerName { get; set; }

        /// <summary>
        /// 取得或設定採購人員姓名。
        /// </summary>
        /// <value>
        /// 採購人員姓名。
        /// </value>
        public string PurchaserName { get; set; }

        /// <summary>
        /// 取得或設定採購主管姓名。
        /// </summary>
        /// <value>
        /// 採購主管姓名。
        /// </value>
        public string StaffName { get; set; }
    }
}
