namespace ErpApi.Entities
{
    /// <summary>
    /// 小類資訊
    /// </summary>
    public class CategoryZone
    {
        /// <summary>
        /// 小類編號
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 小類名稱
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 子站資訊
        /// </summary>
        public Category[] Categories { get; set; }
    }
}