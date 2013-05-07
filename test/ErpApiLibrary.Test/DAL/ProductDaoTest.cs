using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ErpApi.DAL
{
    [TestClass]
    public class ProductDaoTest
    {
        [TestMethod]
        public void UpdateSize_productId_12002()
        {
            IProductDao target = new ProductDao();

            var updatedProduct = target.UpdateSize(12002, 10.1f, 10.2f, 10.3f, 99, "ErpApiTest");

            Assert.AreEqual(12002, updatedProduct.Id);
            Assert.AreEqual(10.1f, updatedProduct.Length);
            Assert.AreEqual(10.2f, updatedProduct.Width);
            Assert.AreEqual(10.3f, updatedProduct.Height);
            Assert.AreEqual(99, updatedProduct.Weight);
            Assert.AreEqual("ErpApiTest", updatedProduct.UpdatedUser);
        }
    }
}