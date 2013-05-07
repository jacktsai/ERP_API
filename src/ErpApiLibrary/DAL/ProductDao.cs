using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using ErpApi.Entities;
using ErpApi.Utility;
using Monday.DataAccess.Common;
using Monday.Environments;

namespace ErpApi.DAL
{
    /// <summary>
    /// <see cref="IProductDao"/> 介面實作。
    /// </summary>
    public class ProductDao : IProductDao
    {
        /// <summary>
        /// The database connection string.
        /// </summary>
        private readonly string _connectionString;

        /// <summary>
        /// Initializes a new instance of the <see cref="RoleDao" /> class.
        /// </summary>
        public ProductDao()
        {
            this._connectionString = Setting.GetConnectionString("sale");
        }

        /// <summary>
        /// 更新商品材積。
        /// </summary>
        /// <param name="productId">商品編號</param>
        /// <param name="length">長(公分)</param>
        /// <param name="width">寬(公分)</param>
        /// <param name="height">高(公分)</param>
        /// <param name="weight">重量(公克)</param>
        /// <param name="updatedUser">更新人員</param>
        /// <returns>
        /// 更新後的商品資料
        /// </returns>
        /// <exception cref="System.ArgumentNullException">updatedUser</exception>
        Product IProductDao.UpdateSize(int productId, float length, float width, float height, int weight, string updatedUser)
        {
            if (string.IsNullOrEmpty(updatedUser))
            {
                throw new ArgumentNullException("updatedUser");
            }

            var commandText = @"
UPDATE
    dbo.product
SET
    product_length = @product_length,
    product_width = @product_width,
    product_height = @product_height,
    product_weight = @product_weight,
    product_updated = product_updated + 1,
    product_updateddate = GETDATE(),
    product_updateduser = @product_updateduser
WHERE
    product_id = @product_id

SELECT
    product_id,
    product_length,
    product_width,
    product_height,
    product_weight,
    product_updateddate,
    product_updateduser
FROM
    dbo.product WITH(NOLOCK)
WHERE
    product_id = @product_id
";
            var idParameter = new SqlParameter("@product_id", productId);
            var lengthParameter = new SqlParameter("@product_length", length);
            var widthParameter = new SqlParameter("@product_width", width);
            var heightParameter = new SqlParameter("@product_height", height);
            var weightParameter = new SqlParameter("@product_weight", weight);
            var userParameter = new SqlParameter("@product_updateduser", updatedUser);

            var result = SqlComm.GetEntityList(
                CommandType.Text,
                commandText,
                this._connectionString,
                dataRow => ColumnMappingHelper.MappingEntity<Product>(dataRow),
                idParameter,
                lengthParameter,
                widthParameter,
                heightParameter,
                weightParameter,
                userParameter);

            return result.First();
        }
    }
}