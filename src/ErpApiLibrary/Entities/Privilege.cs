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
        public Int32 privilege_id { get; set; }

        /// <summary>
        /// privilege_prifuncid。
        /// </summary>
        [DBColumnMapping("privilege_prifuncid")]
        public Int32 privilege_prifuncid { get; set; }

        /// <summary>
        /// privilege_priuserid。
        /// </summary>
        [DBColumnMapping("privilege_priuserid")]
        public Int32 privilege_priuserid { get; set; }

        /// <summary>
        /// privilege_date。
        /// </summary>
        [DBColumnMapping("privilege_date")]
        public DateTime privilege_date { get; set; }

        /// <summary>
        /// privilege_note。
        /// </summary>
        [DBColumnMapping("privilege_note")]
        public string privilege_note { get; set; }

        /// <summary>
        /// privilege_sysdate。
        /// </summary>
        [DBColumnMapping("privilege_sysdate")]
        public DateTime privilege_sysdate { get; set; }

        /// <summary>
        /// privilege_updated。
        /// </summary>
        [DBColumnMapping("privilege_updated")]
        public Byte privilege_updated { get; set; }

        /// <summary>
        /// privilege_updateddate。
        /// </summary>
        [DBColumnMapping("privilege_updateddate")]
        public DateTime privilege_updateddate { get; set; }

        /// <summary>
        /// privilege_updateduser。
        /// </summary>
        [DBColumnMapping("privilege_updateduser")]
        public string privilege_updateduser { get; set; }

        /// <summary>
        /// privilege_prigroupid。
        /// </summary>
        [DBColumnMapping("privilege_prigroupid")]
        public Int32? privilege_prigroupid { get; set; }
    }
}