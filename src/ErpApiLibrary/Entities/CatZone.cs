using System;
using Monday.DataAccess.Common;

namespace ErpApi.Entities
{
    /// <summary>
    /// mapping table name: catzone。
    /// </summary>
    public class CatZone
    {
        /// <summary>
        /// catzone_id。
        /// </summary>
        [DBColumnMapping("catzone_id")]
        public short Id { get; set; }

        /// <summary>
        /// catzone_name。
        /// </summary>
        [DBColumnMapping("catzone_name")]
        public string Name { get; set; }

        /// <summary>
        /// catzone_sort。
        /// </summary>
        [DBColumnMapping("catzone_sort")]
        public short Sort { get; set; }

        /// <summary>
        /// 隸屬PM部門。
        /// </summary>
        [DBColumnMapping("catzone_pmdep")]
        public string PmDep { get; set; }

        /// <summary>
        /// catzone_user。
        /// </summary>
        [DBColumnMapping("catzone_user")]
        public string User { get; set; }

        /// <summary>
        /// catzone_sysdate。
        /// </summary>
        [DBColumnMapping("catzone_sysdate")]
        public DateTime SysDate { get; set; }

        /// <summary>
        /// catzone_updated。
        /// </summary>
        [DBColumnMapping("catzone_updated")]
        public byte Updated { get; set; }

        /// <summary>
        /// catzone_updateddate。
        /// </summary>
        [DBColumnMapping("catzone_updateddate")]
        public DateTime UpdatedDate { get; set; }

        /// <summary>
        /// catzone_updateduser。
        /// </summary>
        [DBColumnMapping("catzone_updateduser")]
        public string UpdatedUser { get; set; }

        /// <summary>
        /// 區類別。
        /// </summary>
        [DBColumnMapping("catzone_type")]
        public byte TypeId { get; set; }

        /// <summary>
        /// 區類別名稱。
        /// </summary>
        [DBColumnMapping("catzone_typename")]
        public string TypeName { get; set; }
    }
}