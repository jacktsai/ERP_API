using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Yahoo.Business.Security
{
    /// <summary>
    /// 頁面授權資訊。
    /// </summary>
    public class Authorization
    {
        /// <summary>
        /// 細部權限-SELECT。
        /// </summary>
        public bool HasSelect { get; set; }

        /// <summary>
        /// 細部權限-INSERT。
        /// </summary>
        public bool HasInsert { get; set; }

        /// <summary>
        /// 細部權限-UPDATE。
        /// </summary>
        public bool HasUpdate { get; set; }

        /// <summary>
        /// 細部權限-DELETE。
        /// </summary>
        public bool HasDelete { get; set; }

        /// <summary>
        /// 細部權限-Particular。
        /// </summary>
        public bool HasParticular { get; set; }
    }
}
