using System;
using TechTalk.SpecFlow;
using System.Net.Http;
using Newtonsoft.Json.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Net;
using System.Net.Http.Formatting;

namespace ErpApi.AcceptanceTest.User
{
    [Binding]
    [Scope(Feature = "GetProfile")]
    public class GetProfileSteps
    {
        private readonly HttpContext context;

        public GetProfileSteps(HttpContext context)
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
            this.context.RequestContent.Add(new JProperty("BackyardId", string.Empty));
        }

        [Given(@"BackyardID為 '(.*)'")]
        public void GivenBackyardID為(string p0)
        {
            this.context.RequestContent.Add(new JProperty("BackyardId", p0));
        }

        [When(@"取得操作者資訊")]
        public void When取得操作者資訊()
        {
            this.context.Send(HttpMethod.Post, "api/user/GetProfile");
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

        [Then(@"回傳操作者序號為 (.*)")]
        public void Then回傳操作者序號為(int p0)
        {
            var PriuserID = this.context.ResponseContent["Id"];
            Assert.AreEqual(p0, PriuserID.Value<int>());
        }

        [Then(@"回傳操作帳號為 '(.*)'")]
        public void Then回傳操作帳號為(string p0)
        {
            var PriuserName = this.context.ResponseContent["Name"];
            Assert.AreEqual(p0, PriuserName.Value<string>());
        }

        [Then(@"回傳操作者中文姓名為 '(.*)'")]
        public void Then回傳操作者中文姓名為(string p0)
        {
            var PriuserFullName = this.context.ResponseContent["FullName"];
            Assert.AreEqual(p0, PriuserFullName.Value<string>());
        }

        [Then(@"回傳操作者部門為 '(.*)'")]
        public void Then回傳操作者部門為(string p0)
        {
            var PriuserDepartment = this.context.ResponseContent["Department"];
            Assert.AreEqual(p0, PriuserDepartment.Value<string>());
        }

        [Then(@"回傳操作者等級為 (.*)")]
        public void Then回傳操作者等級為(int p0)
        {
            var PriuserDegree = this.context.ResponseContent["Degree"];
            Assert.AreEqual(p0, PriuserDegree.Value<int>());
        }

        [Then(@"回傳操作者首頁為 '(.*)'")]
        public void Then回傳操作者首頁為(string p0)
        {
            var PriuserHomepage = this.context.ResponseContent["Homepage"];
            Assert.AreEqual(p0, PriuserHomepage.Value<string>());
        }

        [Then(@"回傳操作者分機為 '(.*)'")]
        public void Then回傳操作者分機為(string p0)
        {
            var PriuserExtno = this.context.ResponseContent["ExtNumber"];
            Assert.AreEqual(p0, PriuserExtno.Value<string>());
        }

        [Then(@"回傳操作者BackyardID為 '(.*)'")]
        public void Then回傳操作者BackyardID為(string p0)
        {
            var BackyardID = this.context.ResponseContent["BackyardID"];
            Assert.AreEqual(p0, BackyardID.Value<string>());
        }

        [Then(@"回傳操作者的子站為 '(.*)'")]
        public void Then回傳操作者的子站為(string p0)
        {
            var CatprivilegeCatsubids = this.context.ResponseContent["SubCatIds"];
            Assert.AreEqual(p0, CatprivilegeCatsubids.Value<string>());
        }
    }
}
