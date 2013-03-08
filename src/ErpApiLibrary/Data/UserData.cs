namespace ErpApi.Data
{
    /// <summary>
    /// 使用者資料。
    /// </summary>
    public class UserData
    {
        /// <summary>
        /// 使用者序號。
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 帳號。
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 姓名。
        /// </summary>
        public string FullName { get; set; }

        /// <summary>
        /// 部門。
        /// </summary>
        public string Department { get; set; }

        /// <summary>
        /// 等級。
        /// </summary>
        public byte Degree { get; set; }

        /// <summary>
        /// Email。
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// 首頁。
        /// </summary>
        public string Homepage { get; set; }

        /// <summary>
        /// 分機。
        /// </summary>
        public string ExtNumber { get; set; }

        /// <summary>
        /// Backyard ID。
        /// </summary>
        public string BackyardId { get; set; }
    }
}