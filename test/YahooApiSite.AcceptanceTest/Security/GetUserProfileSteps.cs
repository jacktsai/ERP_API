using System;
using TechTalk.SpecFlow;
using System.Net.Http;
using Newtonsoft.Json.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Net;
using System.Net.Http.Formatting;

namespace Yahoo.Security
{
    [Binding]
    [Scope(Feature = "GetUserProfile")]
    public class GetUserProfileSteps
    {
        private readonly HttpContext context;

        public GetUserProfileSteps(HttpContext context)
        {
            this.context = context;
        }

        [Given(@"無操作者序號")]
        public void Given無操作者序號()
        {
            this.context.RequestContent = new JObject
            (
                new JProperty("UserId", null)
            );
        }

        [Given(@"操作者序號為空白")]
        public void Given操作者序號為空白()
        {
            this.context.RequestContent = new JObject
            (
                new JProperty("UserId", "")
            );
        }

        [Given(@"操作者序號為 (.*)")]
        public void Given操作者序號為(int p0)
        {
            this.context.RequestContent = new JObject
            (
               new JProperty("UserId", p0)
            );
        }

        [When(@"取得操作者資訊")]
        public void When取得操作者資訊()
        {
            this.context.Send(HttpMethod.Post, "api/security/GetProfile");
        }

        [Then(@"回傳成功狀態")]
        public void Then回傳成功狀態()
        {
            Assert.IsTrue(this.context.IsSuccess, this.context.ErrorMessage);
        }

        [Then(@"回傳狀態為 ""(.*)""")]
        public void Then回傳狀態為(HttpStatusCode p0)
        {
            Assert.AreEqual(p0, this.context.StatusCode);
        }

        [Then(@"回傳操作者序號為 (.*)")]
        public void Then回傳操作者序號為(int p0)
        {
            var PriuserID = this.context.ResponseContent["PriuserID"];
            Assert.AreEqual(p0, PriuserID.Value<int>());
        }

        [Then(@"回傳操作帳號為 ""(.*)""")]
        public void Then回傳操作帳號為(string p0)
        {
            var PriuserName = this.context.ResponseContent["PriuserName"];
            Assert.AreEqual(p0, PriuserName.Value<string>());
        }

        [Then(@"回傳操作者的子站為 ""(.*)""")]
        public void Then回傳操作者的子站為(string p0)
        {
            var CatprivilegeCatsubids = this.context.ResponseContent["CatprivilegeCatsubids"];
            Assert.AreEqual(p0, CatprivilegeCatsubids.Value<string>());
        }

        [Then(@"回傳操作者中文姓名為 ""(.*)""")]
        public void Then回傳操作者中文姓名為(string p0)
        {
            var PriuserFullName = this.context.ResponseContent["PriuserFullName"];
            Assert.AreEqual(p0, PriuserFullName.Value<string>());
        }

        [Then(@"回傳操作者部門為 ""(.*)""")]
        public void Then回傳操作者部門為(string p0)
        {
            var PriuserDepartment = this.context.ResponseContent["PriuserDepartment"];
            Assert.AreEqual(p0, PriuserDepartment.Value<string>());
        }

        [Then(@"回傳操作者等級為 (.*)")]
        public void Then回傳操作者等級為(int p0)
        {
            var PriuserDegree = this.context.ResponseContent["PriuserDegree"];
            Assert.AreEqual(p0, PriuserDegree.Value<int>());
        }

        [Then(@"回傳操作者首頁為 ""(.*)""")]
        public void Then回傳操作者首頁為(string p0)
        {
            var PriuserHomepage = this.context.ResponseContent["PriuserHomepage"];
            Assert.AreEqual(p0, PriuserHomepage.Value<string>());
        }

        [Then(@"回傳操作者分機為 ""(.*)""")]
        public void Then回傳操作者分機為(string p0)
        {
            var PriuserExtno = this.context.ResponseContent["PriuserExtno"];
            Assert.AreEqual(p0, PriuserExtno.Value<string>());
        }

        [Then(@"回傳操作者Backyard ID 為 ""(.*)""")]
        public void Then回傳操作者BackyardID為(string p0)
        {
            var BackyardID = this.context.ResponseContent["BackyardID"];
            Assert.AreEqual(p0, BackyardID.Value<string>());
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
