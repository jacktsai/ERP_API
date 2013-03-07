using System;
using TechTalk.SpecFlow;
using System.Net.Http;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using System.Net.Http.Formatting;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Net;

namespace ErpApi.Test
{
    [Binding]
    [Scope(Feature = "GetUserAuthority")]
    public class GetUserAuthoritySteps
    {
        private readonly HttpContext _context;

        public GetUserAuthoritySteps(HttpContext context)
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

        [Given(@"無目標網址")]
        public void Given無目標網址()
        {
            this._context.SetRequestValue("Url", null);
        }

        [Given(@"目標網址為空白")]
        public void Given目標網址為空白()
        {
            this._context.SetRequestValue("Url", "");
        }

        [Given(@"目標網址為 '(.*)'")]
        public void Given目標網址為(string url)
        {
            this._context.SetRequestValue("Url", url);
        }

        [When(@"取得操作權限")]
        public void When取得操作權限()
        {
            this._context.Send(HttpMethod.Post, "api/User/GetAuthority");
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

        [Then(@"回傳使用者BardyardID為 '(.*)'")]
        public void Then回傳使用者BardyardID為(string expected)
        {
            this._context.ResponseContent.AssertAreEqual("BackyardId", expected);
        }

        [Then(@"回傳目標網址為 '(.*)'")]
        public void Then回傳目標網址為(string expected)
        {
            this._context.ResponseContent.AssertAreEqual("Url", expected);
        }

        [Then(@"回傳讀取權限為 (True|False)")]
        public void Then回傳讀取權限為(bool expected)
        {
            this._context.ResponseContent.AssertAreEqual("CanAccess", expected);
        }

        [Then(@"回傳SELECT權限為 (True|False)")]
        public void Then回傳SELECT權限為(bool expected)
        {
            this._context.ResponseContent.AssertAreEqual("CanSelect", expected);
        }

        [Then(@"回傳INSERT權限為 (True|False)")]
        public void Then回傳INSERT權限為(bool expected)
        {
            this._context.ResponseContent.AssertAreEqual("CanInsert", expected);
        }

        [Then(@"回傳UPDATE權限為 (True|False)")]
        public void Then回傳UPDATE權限為(bool expected)
        {
            this._context.ResponseContent.AssertAreEqual("CanUpdate", expected);
        }

        [Then(@"回傳DELETE權限為 (True|False)")]
        public void Then回傳DELETE權限為(bool expected)
        {
            this._context.ResponseContent.AssertAreEqual("CanDelete", expected);
        }

        [Then(@"回傳特殊權限為 (True|False)")]
        public void Then回傳特殊權限為(bool expected)
        {
            this._context.ResponseContent.AssertAreEqual("CanParticular", expected);
        }
    }
}
