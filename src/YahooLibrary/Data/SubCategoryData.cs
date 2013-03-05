using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Yahoo.Data
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
        /// 子站名稱。
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 區編號。
        /// </summary>
        public short ZoneId { get; set; }

        /// <summary>
        /// PM 名稱。
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// PM 主管名稱。
        /// </summary>
        public string ManagerName { get; set; }

        /// <summary>
        /// 採購人員名稱。
        /// </summary>
        public string PurchaserName { get; set; }

        /// <summary>
        /// 採購主管名稱。
        /// </summary>
        public string StaffName { get; set; }
    }
}
