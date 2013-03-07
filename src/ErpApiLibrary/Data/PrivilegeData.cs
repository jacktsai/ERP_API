namespace ErpApi.Data
{
    /// <summary>
    /// 使用者功能授權資料。
    /// </summary>
    public class PrivilegeData
    {
        /// <summary>
        /// Gets or sets the id.
        /// </summary>
        /// <value>
        /// The id.
        /// </value>
        public int Id { get; set; }

        /// <summary>
        /// 使用者序號。
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// Gets or sets the function id.
        /// </summary>
        /// <value>
        /// The function id.
        /// </value>
        public int FunctionId { get; set; }

        /// <summary>
        /// Gets or sets the note.
        /// </summary>
        /// <value>
        /// The note.
        /// </value>
        public string Note { get; set; }
    }
}