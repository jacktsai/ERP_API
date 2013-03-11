using System;
using Monday.DataAccess.Common;

namespace ErpApi.Entities
{
    /// <summary>
    /// mapping table name: roles。
    /// </summary>
    public class Role
    {
        /// <summary>
        /// 流水號。
        /// </summary>
        [DBColumnMapping("roles_id")]
        public Int32 roles_id { get; set; }

        /// <summary>
        /// 角色名稱。
        /// </summary>
        [DBColumnMapping("roles_name")]
        public string roles_name { get; set; }

        /// <summary>
        /// 角色擁有權限二進位數字加總。
        /// </summary>
        [DBColumnMapping("roles_decimalprivs")]
        public Int32 roles_decimalprivs { get; set; }

        /// <summary>
        /// 是否有 SELECT 權限。
        /// </summary>
        [DBColumnMapping("roles_select")]
        public Boolean? roles_select { get; set; }

        /// <summary>
        /// 是否有 INSERT 權限。
        /// </summary>
        [DBColumnMapping("roles_insert")]
        public Boolean? roles_insert { get; set; }

        /// <summary>
        /// 是否有 UPDATE 權限。
        /// </summary>
        [DBColumnMapping("roles_update")]
        public Boolean? roles_update { get; set; }

        /// <summary>
        /// 是否有 DELETE 權限。
        /// </summary>
        [DBColumnMapping("roles_delete")]
        public Boolean? roles_delete { get; set; }

        /// <summary>
        /// 是否有特殊權限。
        /// </summary>
        [DBColumnMapping("roles_particular")]
        public Boolean? roles_particular { get; set; }

        /// <summary>
        /// 備註。
        /// </summary>
        [DBColumnMapping("roles_note")]
        public string roles_note { get; set; }

        /// <summary>
        /// 建檔人。
        /// </summary>
        [DBColumnMapping("roles_sysuser")]
        public string roles_sysuser { get; set; }

        /// <summary>
        /// 建檔日。
        /// </summary>
        [DBColumnMapping("roles_sysdate")]
        public DateTime roles_sysdate { get; set; }

        /// <summary>
        /// 最後修改人。
        /// </summary>
        [DBColumnMapping("roles_updateduser")]
        public string roles_updateduser { get; set; }

        /// <summary>
        /// 最後修改日。
        /// </summary>
        [DBColumnMapping("roles_updateddate")]
        public DateTime roles_updateddate { get; set; }

        /// <summary>
        /// 修改版號。
        /// </summary>
        [DBColumnMapping("roles_updated")]
        public Byte roles_updated { get; set; }
    }
}