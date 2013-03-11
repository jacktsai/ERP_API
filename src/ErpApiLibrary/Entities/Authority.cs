using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ErpApi.Entities
{
    /// <summary>
    /// 使用者 URL 的權限資訊。
    /// </summary>
    public class Authority
    {
        /// <summary>
        /// 是否可以連到 URL 的權限。
        /// </summary>
        public bool CanAccess { get; internal set; }

        /// <summary>
        /// 是否有 SELECT 權限。
        /// </summary>
        public bool CanSelect { get; internal set; }

        /// <summary>
        /// 是否有 INSERT 權限。
        /// </summary>
        public bool CanInsert { get; internal set; }

        /// <summary>
        /// 是否有 UPDATE 權限。
        /// </summary>
        public bool CanUpdate { get; internal set; }

        /// <summary>
        /// 是否有 DELETE 權限。
        /// </summary>
        public bool CanDelete { get; internal set; }

        /// <summary>
        /// 是否有特殊權限。
        /// </summary>
        public bool CanParticular { get; internal set; }
    }
}
