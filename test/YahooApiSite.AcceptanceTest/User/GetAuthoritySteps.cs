using System;
using TechTalk.SpecFlow;
using System.Net.Http;
using System.Collections.Generic;
using Yahoo.Business.Security;
using Newtonsoft.Json.Linq;
using System.Net.Http.Formatting;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Net;

namespace Yahoo.User
{
    [Binding]
    [Scope(Feature = "GetAuthority")]
    public class GetAuthoritySteps
    {
        private readonly HttpContext context;

        public GetAuthoritySteps(HttpContext context)
        {
            this.context = context;
        }

        [Given(@"無BackyardID")]
        public void Given無BackyardID()
        {
            this.context.RequestContent.Add(new JProperty("BackyardId", null));
        }

        [Given(@"BackyardID為空白")]
        public void GivenBackyardID為空白()
        {
            this.context.RequestContent.Add(new JProperty("BackyardId", ""));
        }

        [Given(@"BackyardID為 '(.*)'")]
        public void GivenBackyardID為(string p0)
        {
            this.context.RequestContent.Add(new JProperty("BackyardId", p0));
        }

        [Given(@"無目標網址")]
        public void Given無目標網址()
        {
            this.context.RequestContent.Add(new JProperty("Url", null));
        }

        [Given(@"目標網址為空白")]
        public void Given目標網址為空白()
        {
            this.context.RequestContent.Add(new JProperty("Url", ""));
        }

        [Given(@"目標網址為 '(.*)'")]
        public void Given目標網址為(string p0)
        {
            this.context.RequestContent.Add(new JProperty("Url", p0));
        }

        [When(@"取得操作權限")]
        public void When取得操作權限()
        {
            this.context.Send(HttpMethod.Post, "api/users/GetAuthority");
        }

        [Then(@"回傳成功狀態")]
        public void Then回傳成功狀態()
        {
            Assert.IsTrue(this.context.IsSuccess, this.context.ErrorMessage);
        }

        [Then(@"回傳狀態為 '(.*)'")]
        public void Then回傳狀態為(HttpStatusCode p0)
        {
            Assert.AreEqual(p0, this.context.StatusCode);
        }

        [Then(@"回傳操作者BardyardID為 '(.*)'")]
        public void Then回傳操作者BardyardID為(string p0)
        {
            var BackyardId = this.context.ResponseContent["BackyardId"];
            Assert.AreEqual(p0, BackyardId.Value<string>());
        }

        [Then(@"回傳目標網址為 '(.*)'")]
        public void Then回傳目標網址為(string p0)
        {
            var Url = this.context.ResponseContent["Url"];
            Assert.AreEqual(p0, Url.Value<string>());
        }

        [Then(@"回傳細部權限-SELECT為 (True|False)")]
        public void Then回傳細部權限_SELECT為(bool p0)
        {
            var HasSelect = this.context.ResponseContent["HasSelect"];
            Assert.AreEqual(p0, HasSelect.Value<bool>());
        }

        [Then(@"回傳細部權限-INSERT為 (True|False)")]
        public void Then回傳細部權限_INSERT為(bool p0)
        {
            var HasInsert = this.context.ResponseContent["HasInsert"];
            Assert.AreEqual(p0, HasInsert.Value<bool>());
        }

        [Then(@"回傳細部權限-UPDATE為 (True|False)")]
        public void Then回傳細部權限_UPDATE為(bool p0)
        {
            var HasUpdate = this.context.ResponseContent["HasUpdate"];
            Assert.AreEqual(p0, HasUpdate.Value<bool>());
        }

        [Then(@"回傳細部權限-DELETE為 (True|False)")]
        public void Then回傳細部權限_DELETE為(bool p0)
        {
            var HasDelete = this.context.ResponseContent["HasDelete"];
            Assert.AreEqual(p0, HasDelete.Value<bool>());
        }

        [Then(@"回傳細部權限-特殊權限為 (True|False)")]
        public void Then回傳細部權限_特殊權限為(bool p0)
        {
            var HasParticular = this.context.ResponseContent["HasParticular"];
            Assert.AreEqual(p0, HasParticular.Value<bool>());
        }
    }
}
