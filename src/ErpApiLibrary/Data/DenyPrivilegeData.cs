using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ErpApi.Data
{
    /// <summary>
    /// Deny Privilege Data。
    /// </summary>
    public class DenyPrivilegeData
    {
        /// <summary>
        /// 序號。
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 使用者序號。
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// URL。
        /// </summary>
        public string Url { get; set; }

        /// <summary>
        /// 拒絕 SELECT 權限。
        /// </summary>
        public bool DenySelect { get; set; }

        /// <summary>
        /// 拒絕 INSERT 權限。
        /// </summary>
        public bool DenyInsert { get; set; }

        /// <summary>
        /// 拒絕 UPDATE 權限。
        /// </summary>
        public bool DenyUpdate { get; set; }

        /// <summary>
        /// 拒絕 DELETE 權限。
        /// </summary>
        public bool DenyDelete { get; set; }

        /// <summary>
        /// 拒絕特殊權限。
        /// </summary>
        public bool DenyParticular { get; set; }
    }
}
