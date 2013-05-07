using System.Runtime.Serialization;

namespace ErpApi.Entities
{
    /// <summary>
    /// UpdateProductSize response format.
    /// </summary>
    [DataContract]
    public class UpdateProductSizeResponse
    {
        /// <summary>
        /// 商品編號
        /// </summary>
        [DataMember]
        public int ProductId { get; set; }

        /// <summary>
        /// 更新後的長(公分)
        /// </summary>
        [DataMember]
        public float Length { get; set; }

        /// <summary>
        /// 更新後的寬(公分)
        /// </summary>
        [DataMember]
        public float Width { get; set; }

        /// <summary>
        /// 更新後的高(公分)
        /// </summary>
        [DataMember]
        public float Height { get; set; }

        /// <summary>
        /// 更新後的重量(公克)
        /// </summary>
        [DataMember]
        public int Weight { get; set; }

        /// <summary>
        /// 更新人員
        /// </summary>
        [DataMember]
        public string UpdatedUser { get; set; }
    }
}