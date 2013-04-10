namespace ErpApi.Entities
{
    /// <summary>
    /// 大類資訊
    /// </summary>
    public class CategoryType
    {
        /// <summary>
        /// 大類編號
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 大類名稱
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 小類資訊
        /// </summary>
        public CategoryZone[] Zones { get; set; }
    }
}