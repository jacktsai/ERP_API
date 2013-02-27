using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Yahoo.Business.Security
{
    /// <summary>
    /// 操作者資訊。
    /// </summary>
    public class UserInfo
    {
        /// <summary>
        /// 操作者編號。
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// 帳號。
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 中文姓名
        /// </summary>
        public string FullName { get; set; }

        /// <summary>
        /// 部門。
        /// </summary>
        public string Department { get; set; }

        /// <summary>
        /// 等級。
        /// </summary>
        public int Degree { get; set; }

        /// <summary>
        /// 首頁。
        /// </summary>
        public string Homepage { get; set; }

        /// <summary>
        /// 分機號碼。
        /// </summary>
        public string ExtensionNumber { get; set; }

        /// <summary>
        /// Backyard ID。
        /// </summary>
        public string BackyardId { get; set; }
    }
}
