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
        /// 取得或設定編號。
        /// </summary>
        /// <value>
        /// 編號。
        /// </value>
        public int Id { get; set; }

        /// <summary>
        /// 取得或設定the name.
        /// </summary>
        /// <value>
        /// 帳號。
        /// </value>
        public string Name { get; set; }

        /// <summary>
        /// 取得或設定the full name.
        /// </summary>
        /// <value>
        /// 中文姓名
        /// </value>
        public string FullName { get; set; }

        /// <summary>
        /// 取得或設定the department.
        /// </summary>
        /// <value>
        /// 部門。
        /// </value>
        public string Department { get; set; }

        /// <summary>
        /// 取得或設定the degree.
        /// </summary>
        /// <value>
        /// 等級。
        /// </value>
        public byte Degree { get; set; }

        /// <summary>
        /// 取得或設定the email.
        /// </summary>
        /// <value>
        /// 電子郵件位址。
        /// </value>
        public string Email { get; set; }

        /// <summary>
        /// 取得或設定the homepage.
        /// </summary>
        /// <value>
        /// 首頁。
        /// </value>
        public string Homepage { get; set; }

        /// <summary>
        /// 取得或設定the ext number.
        /// </summary>
        /// <value>
        /// 分機號碼。
        /// </value>
        public string ExtNumber { get; set; }

        /// <summary>
        /// 取得或設定the backyard id.
        /// </summary>
        /// <value>
        /// Backyard ID。
        /// </value>
        public string BackyardId { get; set; }
    }
}
