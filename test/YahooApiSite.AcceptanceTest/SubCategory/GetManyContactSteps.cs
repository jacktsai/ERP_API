using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using Newtonsoft.Json.Linq;
using System.Net.Http;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Net;

namespace Yahoo.SubCategory
{
    [Binding]
    [Scope(Feature = "GetManyContact")]
    public class GetManyContactSteps
    {
        private readonly HttpContext context;

        public GetManyContactSteps(HttpContext context)
        {
            this.context = context;
        }

        [Given(@"無子站代碼")]
        public void Given無子站代碼()
        {
            this.context.RequestContent.Add(new JProperty("SubCategoryIds", null));
        }

        [Given(@"子站代碼為空白")]
        public void Given子站代碼為空白()
        {
            this.context.RequestContent.Add(new JProperty("SubCategoryIds", string.Empty));
        }

        [Given(@"子站代碼為 (.*)")]
        public void Given子站代碼為(string p0)
        {
            var idArray = p0.Split(',').Select(s => int.Parse(s)).ToArray();
            this.context.RequestContent.Add(new JProperty("SubCategoryIds", idArray));
        }

        [When(@"取得聯絡人資訊")]
        public void When取得聯絡人資訊()
        {
            this.context.Send(HttpMethod.Post, "api/SubCategory/GetManyContact");
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

        private JObject GetObject(int index)
        {
            JArray array = this.context.ResponseContent["Contacts"] as JArray;
            return array[index - 1].Value<JObject>();
        }

        [Then(@"回傳第 (.*) 個子站代碼為 (.*)")]
        public void Then回傳第個子站代碼為(int index, int p0)
        {
            var token = this.GetObject(index)["SubCategoryId"];
            Assert.AreEqual(p0, token.Value<int>());
        }

        [Then(@"回傳第 (.*) 個負責PM的BackyardID為 '(.*)'")]
        public void Then回傳第個負責PM的BackyardID為(int index, string p0)
        {
            var token = this.GetObject(index)["UserBackyardId"];
            Assert.AreEqual(p0, token.Value<string>());
        }

        [Then(@"回傳第 (.*) 個負責PM的中文名稱為 '(.*)'")]
        public void Then回傳第個負責PM的中文名稱為(int index, string p0)
        {
            var token = this.GetObject(index)["UserFullName"];
            Assert.AreEqual(p0, token.Value<string>());
        }

        [Then(@"回傳第 (.*) 個負責PM的分機為 '(.*)'")]
        public void Then回傳第個負責PM的分機為(int index, string p0)
        {
            var token = this.GetObject(index)["UserExtNo"];
            Assert.AreEqual(p0, token.Value<string>());
        }

        [Then(@"回傳第 (.*) 個負責PM的Email為 '(.*)'")]
        public void Then回傳第個負責PM的Email為(int index, string p0)
        {
            var token = this.GetObject(index)["UserEmail"];
            Assert.AreEqual(p0, token.Value<string>());
        }

        [Then(@"回傳第 (.*) 個PM主管的BackyardID為 '(.*)'")]
        public void Then回傳第個PM主管的BackyardID為(int index, string p0)
        {
            var token = this.GetObject(index)["MgrBackyardId"];
            Assert.AreEqual(p0, token.Value<string>());
        }

        [Then(@"回傳第 (.*) 個PM主管的中文名稱為 '(.*)'")]
        public void Then回傳第個PM主管的中文名稱為(int index, string p0)
        {
            var token = this.GetObject(index)["MgrFullName"];
            Assert.AreEqual(p0, token.Value<string>());
        }

        [Then(@"回傳第 (.*) 個PM主管的分機為 '(.*)'")]
        public void Then回傳第個PM主管的分機為(int index, string p0)
        {
            var token = this.GetObject(index)["MgrExtNo"];
            Assert.AreEqual(p0, token.Value<string>());
        }

        [Then(@"回傳第 (.*) 個PM主管的Email為 '(.*)'")]
        public void Then回傳第個PM主管的Email為(int index, string p0)
        {
            var token = this.GetObject(index)["MgrEmail"];
            Assert.AreEqual(p0, token.Value<string>());
        }

        [Then(@"回傳第 (.*) 個採購人員的BackyardID為 '(.*)'")]
        public void Then回傳第個採購人員的BackyardID為(int index, string p0)
        {
            var token = this.GetObject(index)["PhrBackyardId"];
            Assert.AreEqual(p0, token.Value<string>());
        }

        [Then(@"回傳第 (.*) 個採購人員的中文名稱為 '(.*)'")]
        public void Then回傳第個採購人員的中文名稱為(int index, string p0)
        {
            var token = this.GetObject(index)["PhrFullName"];
            Assert.AreEqual(p0, token.Value<string>());
        }

        [Then(@"回傳第 (.*) 個採購人員的分機為 '(.*)'")]
        public void Then回傳第個採購人員的分機為(int index, string p0)
        {
            var token = this.GetObject(index)["PhrExtNo"];
            Assert.AreEqual(p0, token.Value<string>());
        }

        [Then(@"回傳第 (.*) 個採購人員的Email為 '(.*)'")]
        public void Then回傳第個採購人員的Email為(int index, string p0)
        {
            var token = this.GetObject(index)["PhrEmail"];
            Assert.AreEqual(p0, token.Value<string>());
        }

        [Then(@"回傳第 (.*) 個採購主任的BackyardID為 '(.*)'")]
        public void Then回傳第個採購主任的BackyardID為(int index, string p0)
        {
            var token = this.GetObject(index)["StaffBackyardId"];
            Assert.AreEqual(p0, token.Value<string>());
        }

        [Then(@"回傳第 (.*) 個採購主任的中文名稱為 '(.*)'")]
        public void Then回傳第個採購主任的中文名稱為(int index, string p0)
        {
            var token = this.GetObject(index)["StaffFullName"];
            Assert.AreEqual(p0, token.Value<string>());
        }

        [Then(@"回傳第 (.*) 個採購主任的分機為 '(.*)'")]
        public void Then回傳第個採購主任的分機為(int index, string p0)
        {
            var token = this.GetObject(index)["StaffExtNo"];
            Assert.AreEqual(p0, token.Value<string>());
        }

        [Then(@"回傳第 (.*) 個採購主任的Email為 '(.*)'")]
        public void Then回傳第個採購主任的Email為(int index, string p0)
        {
            var token = this.GetObject(index)["StaffEmail"];
            Assert.AreEqual(p0, token.Value<string>());
        }
    }
}
