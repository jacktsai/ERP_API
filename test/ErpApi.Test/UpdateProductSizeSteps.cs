using System;
using TechTalk.SpecFlow;
using ErpApi.Entities;
using System.Net.Http;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ErpApi.Test
{
    [Binding]
    [Scope(Feature = "UpdateProductSize")]
    public class UpdateProductSizeSteps
    {
        private readonly HttpContext _context;
        private UpdateProductSizeResponse _response;

        public UpdateProductSizeSteps(HttpContext context)
        {
            this._context = context;
        }

        [Given(@"無商品編號")]
        public void Given無商品編號()
        {
            this._context.SetRequestValue("ProductId", null);
        }

        [Given(@"空白商品編號")]
        public void Given空白商品編號()
        {
            this._context.SetRequestValue("ProductId", string.Empty);
        }

        [Given(@"商品編號為 (.*)")]
        public void Given商品編號為(int productId)
        {
            this._context.SetRequestValue("ProductId", productId);
        }

        [Given(@"長度為 (.*)")]
        public void Given長度為(float length)
        {
            this._context.SetRequestValue("Length", length);
        }

        [Given(@"寬度為 (.*)")]
        public void Given寬度為(float width)
        {
            this._context.SetRequestValue("Width", width);
        }

        [Given(@"高度為 (.*)")]
        public void Given高度為(float height)
        {
            this._context.SetRequestValue("Height", height);
        }

        [Given(@"重量為 (.*)")]
        public void Given重量為(int weight)
        {
            this._context.SetRequestValue("Weight", weight);
        }

        [Given(@"進倉單號為 '(.*)'")]
        public void Given進倉單號為(string inboundNumber)
        {
            this._context.SetRequestValue("InboundNumber", inboundNumber);
        }

        [When(@"更新商品材積")]
        public void When更新商品材積()
        {
            this._response = this._context.Send<UpdateProductSizeResponse>(HttpMethod.Post, "api/Product/UpdateSize");
        }

        [Then(@"更新後的商品編號為 (.*)")]
        public void Then更新後的商品編號為(int productId)
        {
            Assert.AreEqual(productId, this._response.ProductId);
        }

        [Then(@"更新後的長度為 (.*)")]
        public void Then更新後的長度為(float length)
        {
            Assert.AreEqual(length, this._response.Length);
        }

        [Then(@"更新後的寬度為 (.*)")]
        public void Then更新後的寬度為(float width)
        {
            Assert.AreEqual(width, this._response.Width);
        }

        [Then(@"更新後的高度為 (.*)")]
        public void Then更新後的高度為(float height)
        {
            Assert.AreEqual(height, this._response.Height);
        }

        [Then(@"更新後的重量為 (.*)")]
        public void Then更新後的重量為(int weight)
        {
            Assert.AreEqual(weight, this._response.Weight);
        }

        [Then(@"更新後的更新人員為 '(.*)'")]
        public void Then更新後的更新人員為(string updatedUser)
        {
            Assert.AreEqual(updatedUser, this._response.UpdatedUser);
        }
    }
}
