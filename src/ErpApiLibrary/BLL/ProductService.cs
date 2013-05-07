using ErpApi.DAL;
using ErpApi.Entities;

namespace ErpApi.BLL
{
    /// <summary>
    /// 介面 <see cref="IProductService"/> 的實作。
    /// </summary>
    public class ProductService : IProductService
    {
        /// <summary>
        /// Gets or sets the product DAO.
        /// </summary>
        /// <value>
        /// The product DAO.
        /// </value>
        public IProductDao ProductDao { get; set; }

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
        Product IProductService.UpdateSize(int productId, float length, float width, float height, int weight, string updatedUser)
        {
            return this.ProductDao.UpdateSize(productId, length, width, height, weight, updatedUser);
        }
    }
}