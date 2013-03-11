using System;
using Monday.DataAccess.Common;

namespace ErpApi.Entities
{
    /// <summary>
    /// mapping table name: priuser。
    /// </summary>
    public class User
    {
        /// <summary>
        /// 使用者序號。
        /// </summary>
        [DBColumnMapping("priuser_id")]
        public Int32 priuser_id { get; set; }

        /// <summary>
        /// 帳號。
        /// </summary>
        [DBColumnMapping("priuser_name")]
        public string priuser_name { get; set; }

        /// <summary>
        /// 姓名。
        /// </summary>
        [DBColumnMapping("priuser_fullname")]
        public string priuser_fullname { get; set; }

        /// <summary>
        /// 密碼。
        /// </summary>
        [DBColumnMapping("priuser_pwd")]
        public string priuser_pwd { get; set; }

        /// <summary>
        /// 公司。
        /// </summary>
        [DBColumnMapping("priuser_company")]
        public string priuser_company { get; set; }

        /// <summary>
        /// 部門。
        /// </summary>
        [DBColumnMapping("priuser_department")]
        public string priuser_department { get; set; }

        /// <summary>
        /// 等級。
        /// </summary>
        [DBColumnMapping("priuser_degree")]
        public Byte priuser_degree { get; set; }

        /// <summary>
        /// 通知信。
        /// </summary>
        [DBColumnMapping("priuser_notice")]
        public string priuser_notice { get; set; }

        /// <summary>
        /// Email。
        /// </summary>
        [DBColumnMapping("priuser_email")]
        public string priuser_email { get; set; }

        /// <summary>
        /// 首頁。
        /// </summary>
        [DBColumnMapping("priuser_homepage")]
        public string priuser_homepage { get; set; }

        /// <summary>
        /// 分機。
        /// </summary>
        [DBColumnMapping("priuser_extno")]
        public string priuser_extno { get; set; }

        /// <summary>
        /// 狀態。
        /// </summary>
        [DBColumnMapping("priuser_status")]
        public Byte priuser_status { get; set; }

        /// <summary>
        /// 狀態改變日。
        /// </summary>
        [DBColumnMapping("priuser_statusdate")]
        public DateTime priuser_statusdate { get; set; }

        /// <summary>
        /// 狀態備註。
        /// </summary>
        [DBColumnMapping("priuser_statusnote")]
        public string priuser_statusnote { get; set; }

        /// <summary>
        /// 建檔日。
        /// </summary>
        [DBColumnMapping("priuser_date")]
        public DateTime priuser_date { get; set; }

        /// <summary>
        /// 備註。
        /// </summary>
        [DBColumnMapping("priuser_note")]
        public string priuser_note { get; set; }

        /// <summary>
        /// 實際建檔日。
        /// </summary>
        [DBColumnMapping("priuser_sysdate")]
        public DateTime priuser_sysdate { get; set; }

        /// <summary>
        /// 次數。
        /// </summary>
        [DBColumnMapping("priuser_updated")]
        public Byte priuser_updated { get; set; }

        /// <summary>
        /// 最後更改日。
        /// </summary>
        [DBColumnMapping("priuser_updateddate")]
        public DateTime priuser_updateddate { get; set; }

        /// <summary>
        /// 最後更改人。
        /// </summary>
        [DBColumnMapping("priuser_updateduser")]
        public string priuser_updateduser { get; set; }

        /// <summary>
        /// priuser_pwdexpired。
        /// </summary>
        [DBColumnMapping("priuser_pwdexpired")]
        public DateTime priuser_pwdexpired { get; set; }

        /// <summary>
        /// priuser_pwdchgdate。
        /// </summary>
        [DBColumnMapping("priuser_pwdchgdate")]
        public DateTime priuser_pwdchgdate { get; set; }

        /// <summary>
        /// 供應商序號。
        /// </summary>
        [DBColumnMapping("priuser_supplierid")]
        public Int32 priuser_supplierid { get; set; }

        /// <summary>
        /// 啟用HinetOTP(1:啟用 0:停用)。
        /// </summary>
        [DBColumnMapping("priuser_otpenabled")]
        public Boolean priuser_otpenabled { get; set; }

        /// <summary>
        /// Backyard ID。
        /// </summary>
        [DBColumnMapping("priuser_backyardid")]
        public string priuser_backyardid { get; set; }

        /// <summary>
        /// 所屬簽核組織。
        /// </summary>
        [DBColumnMapping("priuser_approvedeptcode")]
        public string priuser_approvedeptcode { get; set; }

        /// <summary>
        /// 代簽人。
        /// </summary>
        [DBColumnMapping("priuser_approveagt")]
        public string priuser_approveagt { get; set; }

        /// <summary>
        /// 代簽人狀態 (0:停用   1:啟用)。
        /// </summary>
        [DBColumnMapping("priuser_approvestatus")]
        public Boolean? priuser_approvestatus { get; set; }

        /// <summary>
        /// 代簽起始日期。
        /// </summary>
        [DBColumnMapping("priuser_approveperiodstart")]
        public DateTime? priuser_approveperiodstart { get; set; }

        /// <summary>
        /// 代簽結束日期。
        /// </summary>
        [DBColumnMapping("priuser_approveperiodend")]
        public DateTime? priuser_approveperiodend { get; set; }
    }
}