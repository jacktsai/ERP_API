using System;
using Monday.DataAccess.Common;

namespace ErpApi.Entities
{
    /// <summary>
    /// mapping table name: priuser。
    /// </summary>
    public class PriUser
    {
        /// <summary>
        /// 使用者序號。
        /// </summary>
        [DBColumnMapping("priuser_id")]
        public int Id { get; set; }

        /// <summary>
        /// 帳號。
        /// </summary>
        [DBColumnMapping("priuser_name")]
        public string Name { get; set; }

        /// <summary>
        /// 姓名。
        /// </summary>
        [DBColumnMapping("priuser_fullname")]
        public string FullName { get; set; }

        /// <summary>
        /// 密碼。
        /// </summary>
        [DBColumnMapping("priuser_pwd")]
        public string Pwd { get; set; }

        /// <summary>
        /// 公司。
        /// </summary>
        [DBColumnMapping("priuser_company")]
        public string Company { get; set; }

        /// <summary>
        /// 部門。
        /// </summary>
        [DBColumnMapping("priuser_department")]
        public string Department { get; set; }

        /// <summary>
        /// 等級。
        /// </summary>
        [DBColumnMapping("priuser_degree")]
        public byte Degree { get; set; }

        /// <summary>
        /// 通知信。
        /// </summary>
        [DBColumnMapping("priuser_notice")]
        public string Notice { get; set; }

        /// <summary>
        /// Email。
        /// </summary>
        [DBColumnMapping("priuser_email")]
        public string Email { get; set; }

        /// <summary>
        /// 首頁。
        /// </summary>
        [DBColumnMapping("priuser_homepage")]
        public string Homepage { get; set; }

        /// <summary>
        /// 分機。
        /// </summary>
        [DBColumnMapping("priuser_extno")]
        public string ExtNo { get; set; }

        /// <summary>
        /// 狀態。
        /// </summary>
        [DBColumnMapping("priuser_status")]
        public byte Status { get; set; }

        /// <summary>
        /// 狀態改變日。
        /// </summary>
        [DBColumnMapping("priuser_statusdate")]
        public DateTime StatusDate { get; set; }

        /// <summary>
        /// 狀態備註。
        /// </summary>
        [DBColumnMapping("priuser_statusnote")]
        public string StatusNote { get; set; }

        /// <summary>
        /// 建檔日。
        /// </summary>
        [DBColumnMapping("priuser_date")]
        public DateTime Date { get; set; }

        /// <summary>
        /// 備註。
        /// </summary>
        [DBColumnMapping("priuser_note")]
        public string Note { get; set; }

        /// <summary>
        /// 實際建檔日。
        /// </summary>
        [DBColumnMapping("priuser_sysdate")]
        public DateTime SysDate { get; set; }

        /// <summary>
        /// 次數。
        /// </summary>
        [DBColumnMapping("priuser_updated")]
        public byte Updated { get; set; }

        /// <summary>
        /// 最後更改日。
        /// </summary>
        [DBColumnMapping("priuser_updateddate")]
        public DateTime UpdatedDate { get; set; }

        /// <summary>
        /// 最後更改人。
        /// </summary>
        [DBColumnMapping("priuser_updateduser")]
        public string UpdatedUser { get; set; }

        /// <summary>
        /// priuser_pwdexpired。
        /// </summary>
        [DBColumnMapping("priuser_pwdexpired")]
        public DateTime PwdExpired { get; set; }

        /// <summary>
        /// priuser_pwdchgdate。
        /// </summary>
        [DBColumnMapping("priuser_pwdchgdate")]
        public DateTime PwdChgDate { get; set; }

        /// <summary>
        /// 供應商序號。
        /// </summary>
        [DBColumnMapping("priuser_supplierid")]
        public int SupplierId { get; set; }

        /// <summary>
        /// 啟用HinetOTP(1:啟用 0:停用)。
        /// </summary>
        [DBColumnMapping("priuser_otpenabled")]
        public bool OtpEnabled { get; set; }

        /// <summary>
        /// Backyard ID。
        /// </summary>
        [DBColumnMapping("priuser_backyardid")]
        public string BackyardId { get; set; }

        /// <summary>
        /// 所屬簽核組織。
        /// </summary>
        [DBColumnMapping("priuser_approvedeptcode")]
        public string ApproveDeptCode { get; set; }

        /// <summary>
        /// 代簽人。
        /// </summary>
        [DBColumnMapping("priuser_approveagt")]
        public string ApproveAgt { get; set; }

        /// <summary>
        /// 代簽人狀態 (0:停用   1:啟用)。
        /// </summary>
        [DBColumnMapping("priuser_approvestatus")]
        public bool? ApproveStatus { get; set; }

        /// <summary>
        /// 代簽起始日期。
        /// </summary>
        [DBColumnMapping("priuser_approveperiodstart")]
        public DateTime? ApprovePeriodStart { get; set; }

        /// <summary>
        /// 代簽結束日期。
        /// </summary>
        [DBColumnMapping("priuser_approveperiodend")]
        public DateTime? ApprovePeriodEnd { get; set; }
    }
}