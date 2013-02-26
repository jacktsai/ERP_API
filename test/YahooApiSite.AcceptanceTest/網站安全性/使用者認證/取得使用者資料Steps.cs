using System;
using TechTalk.SpecFlow;
using System.Net.Http;
using Newtonsoft.Json.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Net;
using System.Net.Http.Formatting;

namespace YahooApiSite.AcceptanceTest.網站安全性.使用者認證
{
    [Binding]
    public class 取得使用者資料Steps : HttpClientStepsBase
    {
        [When(@"無操作者序號取得登入資訊")]
        public void When無操作者序號取得登入資訊()
        {
            var requestContent = new JObject
            (
            );

            SendRequest(HttpMethod.Post, "api/security/GetProfile", requestContent);
        }

        [When(@"以 null 操作者序號取得登入資訊")]
        public void When以空白操作者序號取得登入資訊()
        {
            var requestContent = new JObject
             (
                 new JProperty("UserId", null)
             );

            SendRequest(HttpMethod.Post, "api/security/GetProfile", requestContent);
        }

        [When(@"以操作者序號 (.*) 取得登入資訊")]
        public void When以操作者序號取得登入資訊(int p0)
        {
            var requestContent = new JObject
            (
                new JProperty("UserId", p0)
            );

            SendRequest(HttpMethod.Post, "api/security/GetProfile", requestContent);
        }

        [Then(@"回傳操作者序號為 (.*)")]
        public void Then回傳操作者序號為(int p0)
        {
            var PriuserID = ResponseContent["PriuserID"];
            Assert.AreEqual(p0, PriuserID.Value<int>());
        }

        [Then(@"回傳操作帳號為 ""(.*)""")]
        public void Then回傳操作帳號為(string p0)
        {
            var PriuserName = ResponseContent["PriuserName"];
            Assert.AreEqual(p0, PriuserName.Value<string>());
        }

        [Then(@"回傳操作者的子站為 ""(.*)""")]
        public void Then回傳操作者的子站為(string p0)
        {
            var CatprivilegeCatsubids = ResponseContent["CatprivilegeCatsubids"];
            Assert.AreEqual(p0, CatprivilegeCatsubids.Value<string>());
        }

        [Then(@"回傳操作者中文姓名為 ""(.*)""")]
        public void Then回傳操作者中文姓名為(string p0)
        {
            var PriuserFullName = ResponseContent["PriuserFullName"];
            Assert.AreEqual(p0, PriuserFullName.Value<string>());
        }

        [Then(@"回傳操作者部門為 ""(.*)""")]
        public void Then回傳操作者部門為(string p0)
        {
            var PriuserDepartment = ResponseContent["PriuserDepartment"];
            Assert.AreEqual(p0, PriuserDepartment.Value<string>());
        }

        [Then(@"回傳操作者等級為 (.*)")]
        public void Then回傳操作者等級為(int p0)
        {
            var PriuserDegree = ResponseContent["PriuserDegree"];
            Assert.AreEqual(p0, PriuserDegree.Value<int>());
        }

        [Then(@"回傳操作者首頁為 ""(.*)""")]
        public void Then回傳操作者首頁為(string p0)
        {
            var PriuserHomepage = ResponseContent["PriuserHomepage"];
            Assert.AreEqual(p0, PriuserHomepage.Value<string>());
        }

        [Then(@"回傳操作者分機為 ""(.*)""")]
        public void Then回傳操作者分機為(string p0)
        {
            var PriuserExtno = ResponseContent["PriuserExtno"];
            Assert.AreEqual(p0, PriuserExtno.Value<string>());
        }

        [Then(@"回傳操作者Backyard ID 為 ""(.*)""")]
        public void Then回傳操作者BackyardID為(string p0)
        {
            var BackyardID = ResponseContent["BackyardID"];
            Assert.AreEqual(p0, BackyardID.Value<string>());
        }

        [Then(@"回傳細部權限-SELECT為 (True|False)")]
        public void Then回傳細部權限_SELECT為(bool p0)
        {
            var HasSelect = ResponseContent["HasSelect"];
            Assert.AreEqual(p0, HasSelect.Value<bool>());
        }

        [Then(@"回傳細部權限-INSERT為 (True|False)")]
        public void Then回傳細部權限_INSERT為(bool p0)
        {
            var HasInsert = ResponseContent["HasInsert"];
            Assert.AreEqual(p0, HasInsert.Value<bool>());
        }

        [Then(@"回傳細部權限-UPDATE為 (True|False)")]
        public void Then回傳細部權限_UPDATE為(bool p0)
        {
            var HasUpdate = ResponseContent["HasUpdate"];
            Assert.AreEqual(p0, HasUpdate.Value<bool>());
        }

        [Then(@"回傳細部權限-DELETE為 (True|False)")]
        public void Then回傳細部權限_DELETE為(bool p0)
        {
            var HasDelete = ResponseContent["HasDelete"];
            Assert.AreEqual(p0, HasDelete.Value<bool>());
        }

        [Then(@"回傳細部權限-特殊權限為 (True|False)")]
        public void Then回傳細部權限_特殊權限為(bool p0)
        {
            var HasParticular = ResponseContent["HasParticular"];
            Assert.AreEqual(p0, HasParticular.Value<bool>());
        }
    }
}
