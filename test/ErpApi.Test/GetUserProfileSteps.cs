using System;
using TechTalk.SpecFlow;
using System.Net.Http;
using Newtonsoft.Json.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Net;
using System.Net.Http.Formatting;

namespace ErpApi.Test
{
    [Binding]
    [Scope(Feature = "GetUserProfile")]
    public class GetUserProfileSteps
    {
        private readonly HttpContext _context;

        public GetUserProfileSteps(HttpContext context)
        {
            this._context = context;
        }

        [Given(@"無BackyardID")]
        public void Given無BackyardID()
        {
            this._context.SetRequestValue("BackyardId", null);
        }

        [Given(@"BackyardID為空白")]
        public void GivenBackyardID為空白()
        {
            this._context.SetRequestValue("BackyardId", string.Empty);
        }

        [Given(@"BackyardID為 '(.*)'")]
        public void GivenBackyardID為(string backyardId)
        {
            this._context.SetRequestValue("BackyardId", backyardId);
        }

        [When(@"取得操作者資訊")]
        public void When取得操作者資訊()
        {
            this._context.Send(HttpMethod.Post, "api/User/GetProfile");
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

        [Then(@"回傳操作者序號為 (.*)")]
        public void Then回傳操作者序號為(int expected)
        {
            this._context.ResponseContent.AssertAreEqual("Id", expected);
        }

        [Then(@"回傳操作帳號為 '(.*)'")]
        public void Then回傳操作帳號為(string expected)
        {
            this._context.ResponseContent.AssertAreEqual("Name", expected);
        }

        [Then(@"回傳操作者中文姓名為 '(.*)'")]
        public void Then回傳操作者中文姓名為(string expected)
        {
            this._context.ResponseContent.AssertAreEqual("FullName", expected);
        }

        [Then(@"回傳操作者部門為 '(.*)'")]
        public void Then回傳操作者部門為(string expected)
        {
            this._context.ResponseContent.AssertAreEqual("Department", expected);
        }

        [Then(@"回傳操作者等級為 (.*)")]
        public void Then回傳操作者等級為(int expected)
        {
            this._context.ResponseContent.AssertAreEqual("Degree", expected);
        }

        [Then(@"回傳操作者首頁為 '(.*)'")]
        public void Then回傳操作者首頁為(string expected)
        {
            this._context.ResponseContent.AssertAreEqual("Homepage", expected);
        }

        [Then(@"回傳操作者分機為 '(.*)'")]
        public void Then回傳操作者分機為(string expected)
        {
            this._context.ResponseContent.AssertAreEqual("ExtNumber", expected);
        }

        [Then(@"回傳操作者BackyardID為 '(.*)'")]
        public void Then回傳操作者BackyardID為(string expected)
        {
            this._context.ResponseContent.AssertAreEqual("BackyardID", expected);
        }

        [Then(@"回傳操作者的子站為 '(.*)'")]
        public void Then回傳操作者的子站為(string expected)
        {
            this._context.ResponseContent.AssertAreEqual("SubCatIds", expected);
        }
    }
}
