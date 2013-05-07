using System;
using System.Linq;
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
        /// <summary>
        /// The instance of HttpContext.
        /// </summary>
        private readonly HttpContext _context;
        private JObject _responseContent;

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

        [When(@"取得使用者資訊")]
        public void When取得使用者資訊()
        {
            this._responseContent = this._context.Send(HttpMethod.Post, "api/User/GetProfile");
        }

        [Then(@"回傳成功狀態")]
        public void Then回傳成功狀態()
        {
            Assert.IsTrue(this._context.IsSuccess, this._context.ErrorMessage);
        }

        [Then(@"回傳狀態為 '(.*)'")]
        public void Then回傳狀態為(HttpStatusCode status)
        {
            Assert.AreEqual(status, this._context.StatusCode);
        }

        [Then(@"回傳使用者序號為 (.*)")]
        public void Then回傳使用者序號為(int id)
        {
            this._responseContent.AssertAreEqual("Id", id);
        }

        [Then(@"回傳使用者帳號為 '(.*)'")]
        public void Then回傳使用者帳號為(string name)
        {
            this._responseContent.AssertAreEqual("Name", name);
        }

        [Then(@"回傳使用者姓名為 '(.*)'")]
        public void Then回傳使用者姓名為(string fullName)
        {
            this._responseContent.AssertAreEqual("FullName", fullName);
        }

        [Then(@"回傳使用者部門為 '(.*)'")]
        public void Then回傳使用者部門為(string department)
        {
            this._responseContent.AssertAreEqual("Department", department);
        }

        [Then(@"回傳使用者等級為 (.*)")]
        public void Then回傳使用者等級為(int degree)
        {
            this._responseContent.AssertAreEqual("Degree", degree);
        }

        [Then(@"回傳使用者首頁為 '(.*)'")]
        public void Then回傳使用者首頁為(string homepage)
        {
            this._responseContent.AssertAreEqual("Homepage", homepage);
        }

        [Then(@"回傳使用者分機為 '(.*)'")]
        public void Then回傳使用者分機為(string extNumber)
        {
            this._responseContent.AssertAreEqual("ExtNumber", extNumber);
        }

        [Then(@"回傳使用者BackyardID為 '(.*)'")]
        public void Then回傳使用者BackyardID為(string backyardId)
        {
            this._responseContent.AssertAreEqual("BackyardId", backyardId);
        }

        [Then(@"回傳子站代碼為 '(.*)'")]
        public void Then回傳子站代碼為(string ids)
        {
            JArray actualIds = this._responseContent.Value<JArray>("CategoryIds");

            if (ids.Length == 0)
            {
                Assert.AreEqual(0, actualIds.Count);
                return;
            }

            var expectedIds = ids.Split(',').Select(s => int.Parse(s)).ToArray();
            Assert.AreEqual(expectedIds.Length, actualIds.Count);
            for (int i = 0; i < expectedIds.Length; i++)
            {
                Assert.AreEqual(expectedIds[i], actualIds[i].Value<int>());
            }
        }
    }
}
