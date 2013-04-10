using System;
using Monday.DataAccess.Common;

namespace ErpApi.Entities
{
    /// <summary>
    /// mapping table name: privilege。
    /// </summary>
    public class Privilege
    {
        /// <summary>
        /// privilege_id。
        /// </summary>
        [DBColumnMapping("privilege_id")]
        public int Id { get; set; }

        /// <summary>
        /// privilege_prifuncid。
        /// </summary>
        [DBColumnMapping("privilege_prifuncid")]
        public int PriFuncId { get; set; }

        /// <summary>
        /// privilege_priuserid。
        /// </summary>
        [DBColumnMapping("privilege_priuserid")]
        public int PriUserId { get; set; }

        /// <summary>
        /// privilege_date。
        /// </summary>
        [DBColumnMapping("privilege_date")]
        public DateTime Date { get; set; }

        /// <summary>
        /// privilege_note。
        /// </summary>
        [DBColumnMapping("privilege_note")]
        public string Note { get; set; }

        /// <summary>
        /// privilege_sysdate。
        /// </summary>
        [DBColumnMapping("privilege_sysdate")]
        public DateTime SysDate { get; set; }

        /// <summary>
        /// privilege_updated。
        /// </summary>
        [DBColumnMapping("privilege_updated")]
        public byte Updated { get; set; }

        /// <summary>
        /// privilege_updateddate。
        /// </summary>
        [DBColumnMapping("privilege_updateddate")]
        public DateTime UpdatedDate { get; set; }

        /// <summary>
        /// privilege_updateduser。
        /// </summary>
        [DBColumnMapping("privilege_updateduser")]
        public string UpdatedUser { get; set; }

        /// <summary>
        /// privilege_prigroupid。
        /// </summary>
        [DBColumnMapping("privilege_prigroupid")]
        public int? PriGroupId { get; set; }
    }
}