using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ErpApi.Data
{
    /// <summary>
    /// 使用者權限資料。
    /// </summary>
    public class AuthorityData
    {
        /// <summary>
        /// 取得或設定是否允許 SELECT。
        /// </summary>
        /// <value>
        /// 是否允許 SELECT。
        /// </value>
        public bool CanSelect { get; set; }

        /// <summary>
        /// 取得或設定是否允許 INSERT。
        /// </summary>
        /// <value>
        /// 是否允許 INSERT。
        /// </value>
        public bool CanInsert { get; set; }

        /// <summary>
        /// 取得或設定是否允許 UPDATE。
        /// </summary>
        /// <value>
        /// 是否允許 UPDATE。
        /// </value>
        public bool CanUpdate { get; set; }

        /// <summary>
        /// 取得或設定是否允許 DELETE。
        /// </summary>
        /// <value>
        /// 是否允許 DELETE。
        /// </value>
        public bool CanDelete { get; set; }

        /// <summary>
        /// 取得或設定是否允許 PARTICULAR。
        /// </summary>
        /// <value>
        /// 是否允許 PARTICULAR。
        /// </value>
        public bool CanParticular { get; set; }

        /// <summary>
        /// 取得或設定是否拒絕 SELECT。
        /// </summary>
        /// <value>
        /// 是否拒絕 SELECT。
        /// </value>
        public bool DenySelect { get; set; }

        /// <summary>
        /// 取得或設定是否拒絕 INSERT。
        /// </summary>
        /// <value>
        /// 是否拒絕 INSERT。
        /// </value>
        public bool DenyInsert { get; set; }

        /// <summary>
        /// 取得或設定是否拒絕 UPDATE。
        /// </summary>
        /// <value>
        /// 是否拒絕 UPDATE。
        /// </value>
        public bool DenyUpdate { get; set; }

        /// <summary>
        /// 取得或設定是否拒絕 DELETE。
        /// </summary>
        /// <value>
        /// 是否拒絕 DELETE。
        /// </value>
        public bool DenyDelete { get; set; }

        /// <summary>
        /// 取得或設定是否拒絕 PARTICULAR。
        /// </summary>
        /// <value>
        /// 是否拒絕 PARTICULAR。
        /// </value>
        public bool DenyParticular { get; set; }
    }
}
