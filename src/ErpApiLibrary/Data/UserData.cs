using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ErpApi.Data
{
    /// <summary>
    /// 操作者資料。
    /// </summary>
    public class UserData
    {
        /// <summary>
        /// 編號。
        /// </summary>
        public int Id { get; set; }

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
        public byte Degree { get; set; }

        /// <summary>
        /// 電子郵件位址。
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// 首頁。
        /// </summary>
        public string Homepage { get; set; }

        /// <summary>
        /// 分機號碼。
        /// </summary>
        public string ExtNumber { get; set; }

        /// <summary>
        /// Backyard ID。
        /// </summary>
        public string BackyardId { get; set; }
    }
}
