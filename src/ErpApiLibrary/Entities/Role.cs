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
        public int Id { get; set; }

        /// <summary>
        /// 角色名稱。
        /// </summary>
        [DBColumnMapping("roles_name")]
        public string Name { get; set; }

        /// <summary>
        /// 角色擁有權限二進位數字加總。
        /// </summary>
        [DBColumnMapping("roles_decimalprivs")]
        public int DecimalPrivs { get; set; }

        /// <summary>
        /// 是否有 SELECT 權限。
        /// </summary>
        [DBColumnMapping("roles_select")]
        public bool? Select { get; set; }

        /// <summary>
        /// 是否有 INSERT 權限。
        /// </summary>
        [DBColumnMapping("roles_insert")]
        public bool? Insert { get; set; }

        /// <summary>
        /// 是否有 UPDATE 權限。
        /// </summary>
        [DBColumnMapping("roles_update")]
        public bool? Update { get; set; }

        /// <summary>
        /// 是否有 DELETE 權限。
        /// </summary>
        [DBColumnMapping("roles_delete")]
        public bool? Delete { get; set; }

        /// <summary>
        /// 是否有特殊權限。
        /// </summary>
        [DBColumnMapping("roles_particular")]
        public bool? Particular { get; set; }

        /// <summary>
        /// 備註。
        /// </summary>
        [DBColumnMapping("roles_note")]
        public string Note { get; set; }

        /// <summary>
        /// 建檔人。
        /// </summary>
        [DBColumnMapping("roles_sysuser")]
        public string SysUser { get; set; }

        /// <summary>
        /// 建檔日。
        /// </summary>
        [DBColumnMapping("roles_sysdate")]
        public DateTime SysDate { get; set; }

        /// <summary>
        /// 最後修改人。
        /// </summary>
        [DBColumnMapping("roles_updateduser")]
        public string UpdatedUser { get; set; }

        /// <summary>
        /// 最後修改日。
        /// </summary>
        [DBColumnMapping("roles_updateddate")]
        public DateTime UpdatedDate { get; set; }

        /// <summary>
        /// 修改版號。
        /// </summary>
        [DBColumnMapping("roles_updated")]
        public byte Updated { get; set; }
    }
}