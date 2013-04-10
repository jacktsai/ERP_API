namespace ErpApi.Entities
{
    /// <summary>
    /// 子站聯絡資訊。
    /// </summary>
    public class CategoryContact
    {
        /// <summary>
        /// 子站代碼。
        /// </summary>
        public int CategoryId { get; set; }

        /// <summary>
        /// 負責 PM ID。
        /// </summary>
        public string PmBackyardId { get; set; }

        /// <summary>
        /// 負責 PM 中文名稱。
        /// </summary>
        public string PmFullName { get; set; }

        /// <summary>
        /// 負責 PM 分機。
        /// </summary>
        public string PmExtNumber { get; set; }

        /// <summary>
        /// 負責 PM Email。
        /// </summary>
        public string PmEmail { get; set; }

        /// <summary>
        /// PM 主管 ID。
        /// </summary>
        public string MgrBackyardId { get; set; }

        /// <summary>
        /// PM 主管中文名稱。
        /// </summary>
        public string MgrFullName { get; set; }

        /// <summary>
        /// PM 主管分機。
        /// </summary>
        public string MgrExtNumber { get; set; }

        /// <summary>
        /// PM 主管Email。
        /// </summary>
        public string MgrEmail { get; set; }

        /// <summary>
        /// 採購人員 ID。
        /// </summary>
        public string PhrBackyardId { get; set; }

        /// <summary>
        /// 採購人員中文名稱。
        /// </summary>
        public string PhrFullName { get; set; }

        /// <summary>
        /// 採購人員分機。
        /// </summary>
        public string PhrExtNumber { get; set; }

        /// <summary>
        /// 採購人員 Email。
        /// </summary>
        public string PhrEmail { get; set; }

        /// <summary>
        /// 採購主任 ID。
        /// </summary>
        public string StaffBackyardId { get; set; }

        /// <summary>
        /// 採購主任中文名稱。
        /// </summary>
        public string StaffFullName { get; set; }

        /// <summary>
        /// 採購主任分機。
        /// </summary>
        public string StaffExtNumber { get; set; }

        /// <summary>
        /// 採購主任 Email。
        /// </summary>
        public string StaffEmail { get; set; }
    }
}