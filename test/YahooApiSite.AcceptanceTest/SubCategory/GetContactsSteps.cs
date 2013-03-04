using System;
using TechTalk.SpecFlow;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Net;
using Newtonsoft.Json.Linq;
using System.Net.Http;

namespace Yahoo.SubCategory
{
    [Binding]
    [Scope(Feature = "GetContacts")]
    public class GetContactsSteps
    {
        private readonly HttpContext context;

        public GetContactsSteps(HttpContext context)
        {
            this.context = context;
        }

        [Given(@"無子站代碼")]
        public void Given無子站代碼()
        {
            this.context.RequestContent.Add(new JProperty("SubCategoryId", null));
        }

        [Given(@"子站代碼為空白")]
        public void Given子站代碼為空白()
        {
            this.context.RequestContent.Add(new JProperty("SubCategoryId", string.Empty));
        }

        [Given(@"子站代碼為 (.*)")]
        public void Given子站代碼為(int p0)
        {
            this.context.RequestContent.Add(new JProperty("SubCategoryId", p0));
        }

        [When(@"取得聯絡人資訊")]
        public void When取得聯絡人資訊()
        {
            this.context.Send(HttpMethod.Post, "api/category/GetContacts");
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

        [Then(@"回傳子站代碼為 (.*)")]
        public void Then回傳子站代碼為(int p0)
        {
            var token = this.context.ResponseContent["SubCategoryId"];
            Assert.AreEqual(p0, token.Value<int>());
        }

        [Then(@"回傳負責PM的BackyardID為 '(.*)'")]
        public void Then回傳負責PM的BackyardID為(string p0)
        {
            var token = this.context.ResponseContent["UserBackyardId"];
            Assert.AreEqual(p0, token.Value<string>());
        }

        [Then(@"回傳負責PM的中文名稱為 '(.*)'")]
        public void Then回傳負責PM的中文名稱為(string p0)
        {
            var token = this.context.ResponseContent["UserFullName"];
            Assert.AreEqual(p0, token.Value<string>());
        }

        [Then(@"回傳負責PM的分機為 '(.*)'")]
        public void Then回傳負責PM的分機為(string p0)
        {
            var token = this.context.ResponseContent["UserExtNo"];
            Assert.AreEqual(p0, token.Value<string>());
        }

        [Then(@"回傳負責PM的Email為 '(.*)'")]
        public void Then回傳負責PM的Email為(string p0)
        {
            var token = this.context.ResponseContent["UserEmail"];
            Assert.AreEqual(p0, token.Value<string>());
        }

        [Then(@"回傳PM主管的BackyardID為 '(.*)'")]
        public void Then回傳PM主管的BackyardID為(string p0)
        {
            var token = this.context.ResponseContent["MgrBackyardId"];
            Assert.AreEqual(p0, token.Value<string>());
        }

        [Then(@"回傳PM主管的中文名稱為 '(.*)'")]
        public void Then回傳PM主管的中文名稱為(string p0)
        {
            var token = this.context.ResponseContent["MgrFullName"];
            Assert.AreEqual(p0, token.Value<string>());
        }

        [Then(@"回傳PM主管的分機為 '(.*)'")]
        public void Then回傳PM主管的分機為(string p0)
        {
            var token = this.context.ResponseContent["MgrExtNo"];
            Assert.AreEqual(p0, token.Value<string>());
        }

        [Then(@"回傳PM主管的Email為 '(.*)'")]
        public void Then回傳PM主管的Email為(string p0)
        {
            var token = this.context.ResponseContent["MgrEmail"];
            Assert.AreEqual(p0, token.Value<string>());
        }

        [Then(@"回傳採購人員的BackyardID為 '(.*)'")]
        public void Then回傳採購人員的BackyardID為(string p0)
        {
            var token = this.context.ResponseContent["PhrBackyardId"];
            Assert.AreEqual(p0, token.Value<string>());
        }

        [Then(@"回傳採購人員的中文名稱為 '(.*)'")]
        public void Then回傳採購人員的中文名稱為(string p0)
        {
            var token = this.context.ResponseContent["PhrFullName"];
            Assert.AreEqual(p0, token.Value<string>());
        }

        [Then(@"回傳採購人員的分機為 '(.*)'")]
        public void Then回傳採購人員的分機為(string p0)
        {
            var token = this.context.ResponseContent["PhrExtNo"];
            Assert.AreEqual(p0, token.Value<string>());
        }

        [Then(@"回傳採購人員的Email為 '(.*)'")]
        public void Then回傳採購人員的Email為(string p0)
        {
            var token = this.context.ResponseContent["PhrEmail"];
            Assert.AreEqual(p0, token.Value<string>());
        }

        [Then(@"回傳採購主任的BackyardID為 '(.*)'")]
        public void Then回傳採購主任的BackyardID為(string p0)
        {
            var token = this.context.ResponseContent["StaffBackyardId"];
            Assert.AreEqual(p0, token.Value<string>());
        }

        [Then(@"回傳採購主任的中文名稱為 '(.*)'")]
        public void Then回傳採購主任的中文名稱為(string p0)
        {
            var token = this.context.ResponseContent["StaffFullName"];
            Assert.AreEqual(p0, token.Value<string>());
        }

        [Then(@"回傳採購主任的分機為 '(.*)'")]
        public void Then回傳採購主任的分機為(string p0)
        {
            var token = this.context.ResponseContent["StaffExtNo"];
            Assert.AreEqual(p0, token.Value<string>());
        }

        [Then(@"回傳採購主任的Email為 '(.*)'")]
        public void Then回傳採購主任的Email為(string p0)
        {
            var token = this.context.ResponseContent["StaffEmail"];
            Assert.AreEqual(p0, token.Value<string>());
        }
    }
}
