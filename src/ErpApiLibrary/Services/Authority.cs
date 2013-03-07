using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ErpApi.Services
{
    /// <summary>
    /// 操作者 URL 的權限資訊。
    /// </summary>
    public class Authority
    {
        /// <summary>
        /// 取得是否可以連到 URL 的權限。
        /// </summary>
        public bool CanAccess { get; internal set; }

        /// <summary>
        /// 取得是否有細部權限-SELECT。
        /// </summary>
        public bool CanSelect { get; internal set; }

        /// <summary>
        /// 取得是否有細部權限-INSERT。
        /// </summary>
        public bool CanInsert { get; internal set; }

        /// <summary>
        /// 取得是否有細部權限-UPDATE。
        /// </summary>
        public bool CanUpdate { get; internal set; }

        /// <summary>
        /// 取得是否有細部權限-DELETE。
        /// </summary>
        public bool CanDelete { get; internal set; }

        /// <summary>
        /// 取得是否有細部權限-PARTICULAR。
        /// </summary>
        public bool CanParticular { get; internal set; }
    }
}
