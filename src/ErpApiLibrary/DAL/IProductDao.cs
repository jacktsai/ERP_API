using ErpApi.Entities;

namespace ErpApi.DAL
{
    /// <summary>
    /// 商品資料存取介面
    /// </summary>
    public interface IProductDao
    {
        /// <summary>
        /// 更新商品材積。
        /// </summary>
        /// <param name="productId">商品編號</param>
        /// <param name="length">長(公分)</param>
        /// <param name="width">寬(公分)</param>
        /// <param name="height">高(公分)</param>
        /// <param name="weight">重量(公克)</param>
        /// <param name="updatedUser">更新人員</param>
        /// <returns>更新後的商品資料</returns>
        Product UpdateSize(int productId, float length, float width, float height, int weight, string updatedUser);
    }
}