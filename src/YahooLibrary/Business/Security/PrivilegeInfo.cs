using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Yahoo.Business.Security
{
    /// <summary>
    /// 權限資訊。
    /// </summary>
    public class PrivilegeInfo
    {
        /// <summary>
        /// 權限編號。
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 功能編號。
        /// </summary>
        public int FunctionId { get; set; }

        /// <summary>
        /// 功能目錄編號。
        /// </summary>
        public int CategoryId { get; set; }

        /// <summary>
        /// 功能子目錄編號。
        /// </summary>
        public int CategorySubId { get; set; }
    }
}
