using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace ErpApi.Entities
{
    /// <summary>
    /// UpdateProductSize request format.
    /// </summary>
    [DataContract]
    public class UpdateProductSizeRequest
    {
        /// <summary>
        /// 商品編號
        /// </summary>
        [DataMember(IsRequired = true), Required]
        public int ProductId { get; set; }

        /// <summary>
        /// 長(公分)
        /// </summary>
        [DataMember(IsRequired = true), Required]
        public float Length { get; set; }

        /// <summary>
        /// 寬(公分)
        /// </summary>
        [DataMember(IsRequired = true), Required]
        public float Width { get; set; }

        /// <summary>
        /// 高(公分)
        /// </summary>
        [DataMember(IsRequired = true), Required]
        public float Height { get; set; }

        /// <summary>
        /// 重量(公克)
        /// </summary>
        [DataMember(IsRequired = true), Required]
        public int Weight { get; set; }

        /// <summary>
        /// 進倉單號
        /// </summary>
        [DataMember(IsRequired = true), Required]
        public string InboundNumber { get; set; }
    }
}