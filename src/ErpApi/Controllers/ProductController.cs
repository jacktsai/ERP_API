using System.Linq;
using System.Web.Http;
using ErpApi.Entities;
using ErpApi.BLL;
using ErpApi.Utilities;

namespace ErpApi.Controllers
{
    /// <summary>
    /// 商品相關服務
    /// </summary>
    public class ProductController : ApiController
    {
        /// <summary>
        /// The instance of <see cref="ErpApi.BLL.IProductService"/> interface.
        /// </summary>
        private readonly IProductService _productService;

        /// <summary>
        /// Initializes a new instance of the <see cref="ProductController" /> class.
        /// </summary>
        public ProductController()
        {
            this._productService = ServiceFactory.GetProductService();
        }

        /// <summary>
        /// 更新商品材積。
        /// </summary>
        /// <param name="request">Request 內容。</param>
        /// <returns>Response 內容。</returns>
        [HttpPost]
        public UpdateProductSizeResponse UpdateSize([FromBody]UpdateProductSizeRequest request)
        {
            var updatedProduct = this._productService.UpdateSize(
                request.ProductId,
                request.Length,
                request.Width,
                request.Height,
                request.Weight,
                request.InboundNumber);

            return new UpdateProductSizeResponse
            {
                ProductId = updatedProduct.Id,
                Length = updatedProduct.Length,
                Width = updatedProduct.Width,
                Height = updatedProduct.Height,
                Weight = updatedProduct.Weight,
                UpdatedUser = updatedProduct.UpdatedUser,
            };
        }
    }
}