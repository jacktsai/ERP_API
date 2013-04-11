using System;
using System.Linq;
using TechTalk.SpecFlow;
using System.Net.Http;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Net;
using Newtonsoft.Json.Linq;
using ErpApi.Entities;

namespace ErpApi.Test
{
    [Binding]
    [Scope(Feature = "GetCategories")]
    public class GetCategoriesSteps
    {
        private readonly HttpContext _context;
        private GetCategoriesResponse _response;

        public GetCategoriesSteps(HttpContext context)
        {
            this._context = context;
        }

        [Given(@"無子站代碼")]
        public void Given無子站代碼()
        {
            this._context.SetRequestValue("CategoryIds", null);
        }

        [Given(@"子站代碼為空白")]
        public void Given子站代碼為空白()
        {
            this._context.SetRequestValue("CategoryIds", string.Empty);
        }

        [Given(@"子站代碼為 (.*)")]
        public void Given子站代碼為(string ids)
        {
            var idArray = ids.Split(',').Select(s => int.Parse(s)).ToArray();
            this._context.SetRequestValue("CategoryIds", idArray);
        }

        [When(@"取得子站資訊")]
        public void When取得子站資訊()
        {
            this._response = this._context.Send<GetCategoriesResponse>(HttpMethod.Post, "api/Category/GetCategories");
        }

        [Then(@"回傳成功狀態")]
        public void Then回傳成功狀態()
        {
            Assert.IsTrue(this._context.IsSuccess, this._context.ErrorMessage);
        }

        [Then(@"回傳狀態為 '(.*)'")]
        public void Then回傳狀態為(HttpStatusCode expected)
        {
            Assert.AreEqual(expected, this._context.StatusCode);
        }

        [Then(@"回傳類別 (\d+) 的名稱為 '(.*)'")]
        public void Then回傳類別的名稱為(int typeId, string typeName)
        {
            var type = this._response.CategoryTypes.Single(o => o.Id == typeId);

            Assert.AreEqual(typeName, type.Name);
        }

        [Then(@"回傳類別 (\d+) 區碼 (\d+) 的名稱為 '(.*)'")]
        public void Then回傳類別區碼的名稱為(int typeId, int zoneId, string zoneName)
        {
            var type = this._response.CategoryTypes.Single(o => o.Id == typeId);
            var zone = type.Zones.Single(o => o.Id == zoneId);

            Assert.AreEqual(zoneName, zone.Name);
        }

        [Then(@"回傳類別 (\d+) 區碼 (\d+) 子站 (\d+) 的名稱為 '(.*)'")]
        public void Then回傳類別區碼子站的名稱為(int typeId, int zoneId, int catId, string catName)
        {
            var type = this._response.CategoryTypes.Single(o => o.Id == typeId);
            var zone = type.Zones.Single(o => o.Id == zoneId);
            var cat = zone.Categories.Single(o => o.Id == catId);

            Assert.AreEqual(catName, cat.Name);
        }
    }
}
