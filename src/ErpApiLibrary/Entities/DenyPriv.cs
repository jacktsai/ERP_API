using System;
using Monday.DataAccess.Common;

namespace ErpApi.Entities
{
    /// <summary>
    /// mapping table name: denyprivs。
    /// </summary>
    public class DenyPriv
    {
        /// <summary>
        /// 序號。
        /// </summary>
        [DBColumnMapping("denyprivs_id")]
        public int Id { get; set; }

        /// <summary>
        /// 拒絕存取 URL。
        /// </summary>
        [DBColumnMapping("denyprivs_url")]
        public string Url { get; set; }

        /// <summary>
        /// 使用者序號。
        /// </summary>
        [DBColumnMapping("denyprivs_priuserid")]
        public int PriUserId { get; set; }

        /// <summary>
        /// 拒絕SELECT權限。
        /// </summary>
        [DBColumnMapping("denyprivs_select")]
        public bool Select { get; set; }

        /// <summary>
        /// 拒絕INSERT權限。
        /// </summary>
        [DBColumnMapping("denyprivs_insert")]
        public bool Insert { get; set; }

        /// <summary>
        /// 拒絕UPDATE權限。
        /// </summary>
        [DBColumnMapping("denyprivs_update")]
        public bool Update { get; set; }

        /// <summary>
        /// 拒絕DELETE權限。
        /// </summary>
        [DBColumnMapping("denyprivs_delete")]
        public bool Delete { get; set; }

        /// <summary>
        /// 拒絕特殊權限。
        /// </summary>
        [DBColumnMapping("denyprivs_particular")]
        public bool Particular { get; set; }

        /// <summary>
        /// 建檔人。
        /// </summary>
        [DBColumnMapping("denyprivs_sysuser")]
        public string SysUser { get; set; }

        /// <summary>
        /// 建檔日。
        /// </summary>
        [DBColumnMapping("denyprivs_sysdate")]
        public DateTime SysDate { get; set; }

        /// <summary>
        /// 最後修改人。
        /// </summary>
        [DBColumnMapping("denyprivs_updateduser")]
        public string UpdatedUser { get; set; }

        /// <summary>
        /// 最後修改日。
        /// </summary>
        [DBColumnMapping("denyprivs_updateddate")]
        public DateTime UpdatedDate { get; set; }

        /// <summary>
        /// 修改次數。
        /// </summary>
        [DBColumnMapping("denyprivs_updated")]
        public byte Updated { get; set; }
    }
}