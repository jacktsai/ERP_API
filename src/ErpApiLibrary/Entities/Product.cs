using System;
using Monday.DataAccess.Common;

namespace ErpApi.Entities
{
    /// <summary>
    /// 商品資料
    /// </summary>
    public sealed class Product
    {
        /// <summary>
        /// 商品序號
        /// </summary>
        [DBColumnMapping("product_id")]
        public int Id { get; set; }

        /// <summary>
        /// 長
        /// </summary>
        [DBColumnMapping("product_length")]
        public float Length { get; set; }

        /// <summary>
        /// 寬
        /// </summary>
        [DBColumnMapping("product_width")]
        public float Width { get; set; }

        /// <summary>
        /// 高
        /// </summary>
        [DBColumnMapping("product_height")]
        public float Height { get; set; }

        /// <summary>
        /// 重量
        /// </summary>
        [DBColumnMapping("product_weight")]
        public int Weight { get; set; }

        /// <summary>
        /// 更新日期
        /// </summary>
        [DBColumnMapping("product_updateddate")]
        public DateTime UpdatedDate { get; set; }

        /// <summary>
        /// 更新人員
        /// </summary>
        [DBColumnMapping("product_updateduser")]
        public string UpdatedUser { get; set; }
    }
}