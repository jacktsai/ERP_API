namespace ErpApi.Data
{
    /// <summary>
    /// 角色資料。
    /// </summary>
    public class RoleData
    {
        /// <summary>
        /// 流水號。
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 角色名稱。
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 備註。
        /// </summary>
        public string Note { get; set; }

        /// <summary>
        /// 是否有 SELECT 權限。
        /// </summary>
        public bool? CanSelect { get; set; }

        /// <summary>
        /// 是否有 INSERT 權限。
        /// </summary>
        public bool? CanInsert { get; set; }

        /// <summary>
        /// 是否有 UPDATE 權限。
        /// </summary>
        public bool? CanUpdate { get; set; }

        /// <summary>
        /// 是否有 DELETE 權限。
        /// </summary>
        public bool? CanDelete { get; set; }

        /// <summary>
        /// 是否有特殊權限。
        /// </summary>
        public bool? CanParticular { get; set; }
    }
}