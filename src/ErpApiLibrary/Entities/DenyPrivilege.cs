using System;
using Monday.DataAccess.Common;

namespace ErpApi.Entities
{
    /// <summary>
    /// mapping table name: denyprivs。
    /// </summary>
    public class DenyPrivilege
    {
        /// <summary>
        /// 序號。
        /// </summary>
        [DBColumnMapping("denyprivs_id")]
        public Int32 denyprivs_id { get; set; }

        /// <summary>
        /// 拒絕存取 URL。
        /// </summary>
        [DBColumnMapping("denyprivs_url")]
        public string denyprivs_url { get; set; }

        /// <summary>
        /// 使用者序號。
        /// </summary>
        [DBColumnMapping("denyprivs_priuserid")]
        public Int32 denyprivs_priuserid { get; set; }

        /// <summary>
        /// 拒絕SELECT權限。
        /// </summary>
        [DBColumnMapping("denyprivs_select")]
        public Boolean denyprivs_select { get; set; }

        /// <summary>
        /// 拒絕INSERT權限。
        /// </summary>
        [DBColumnMapping("denyprivs_insert")]
        public Boolean denyprivs_insert { get; set; }

        /// <summary>
        /// 拒絕UPDATE權限。
        /// </summary>
        [DBColumnMapping("denyprivs_update")]
        public Boolean denyprivs_update { get; set; }

        /// <summary>
        /// 拒絕DELETE權限。
        /// </summary>
        [DBColumnMapping("denyprivs_delete")]
        public Boolean denyprivs_delete { get; set; }

        /// <summary>
        /// 拒絕特殊權限。
        /// </summary>
        [DBColumnMapping("denyprivs_particular")]
        public Boolean denyprivs_particular { get; set; }

        /// <summary>
        /// 建檔人。
        /// </summary>
        [DBColumnMapping("denyprivs_sysuser")]
        public string denyprivs_sysuser { get; set; }

        /// <summary>
        /// 建檔日。
        /// </summary>
        [DBColumnMapping("denyprivs_sysdate")]
        public DateTime denyprivs_sysdate { get; set; }

        /// <summary>
        /// 最後修改人。
        /// </summary>
        [DBColumnMapping("denyprivs_updateduser")]
        public string denyprivs_updateduser { get; set; }

        /// <summary>
        /// 最後修改日。
        /// </summary>
        [DBColumnMapping("denyprivs_updateddate")]
        public DateTime denyprivs_updateddate { get; set; }

        /// <summary>
        /// 修改次數。
        /// </summary>
        [DBColumnMapping("denyprivs_updated")]
        public Byte denyprivs_updated { get; set; }
    }
}