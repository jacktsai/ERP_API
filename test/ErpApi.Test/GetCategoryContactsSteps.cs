using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using Newtonsoft.Json.Linq;
using System.Net.Http;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Net;

namespace ErpApi.Test
{
    [Binding]
    [Scope(Feature = "GetCategoryContacts")]
    public class GetCategoryContactsSteps
    {
        private readonly HttpContext _context;
        private JObject _responseContent;

        public GetCategoryContactsSteps(HttpContext context)
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

        [When(@"取得聯絡人資訊")]
        public void When取得聯絡人資訊()
        {
            this._responseContent = this._context.Send(HttpMethod.Post, "api/Category/GetCategoryContacts");
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

        private JObject GetElement(int index)
        {
            JArray array = this._responseContent.Value<JArray>("CategoryContacts");
            return array[index - 1].Value<JObject>();
        }

        [Then(@"回傳第 (.*) 個子站代碼為 (.*)")]
        public void Then回傳第個子站代碼為(int index, int expected)
        {
            this.GetElement(index).AssertAreEqual("CategoryId", expected);
        }

        [Then(@"回傳第 (.*) 個負責PM的BackyardID為 '(.*)'")]
        public void Then回傳第個負責PM的BackyardID為(int index, string expected)
        {
            this.GetElement(index).AssertAreEqual("PmBackyardId", expected);
        }

        [Then(@"回傳第 (.*) 個負責PM的中文名稱為 '(.*)'")]
        public void Then回傳第個負責PM的中文名稱為(int index, string expected)
        {
            this.GetElement(index).AssertAreEqual("PmFullName", expected);
        }

        [Then(@"回傳第 (.*) 個負責PM的分機為 '(.*)'")]
        public void Then回傳第個負責PM的分機為(int index, string expected)
        {
            this.GetElement(index).AssertAreEqual("PmExtNumber", expected);
        }

        [Then(@"回傳第 (.*) 個負責PM的Email為 '(.*)'")]
        public void Then回傳第個負責PM的Email為(int index, string expected)
        {
            this.GetElement(index).AssertAreEqual("PmEmail", expected);
        }

        [Then(@"回傳第 (.*) 個PM主管的BackyardID為 '(.*)'")]
        public void Then回傳第個PM主管的BackyardID為(int index, string expected)
        {
            this.GetElement(index).AssertAreEqual("MgrBackyardId", expected);
        }

        [Then(@"回傳第 (.*) 個PM主管的中文名稱為 '(.*)'")]
        public void Then回傳第個PM主管的中文名稱為(int index, string expected)
        {
            this.GetElement(index).AssertAreEqual("MgrFullName", expected);
        }

        [Then(@"回傳第 (.*) 個PM主管的分機為 '(.*)'")]
        public void Then回傳第個PM主管的分機為(int index, string expected)
        {
            this.GetElement(index).AssertAreEqual("MgrExtNumber", expected);
        }

        [Then(@"回傳第 (.*) 個PM主管的Email為 '(.*)'")]
        public void Then回傳第個PM主管的Email為(int index, string expected)
        {
            this.GetElement(index).AssertAreEqual("MgrEmail", expected);
        }

        [Then(@"回傳第 (.*) 個採購人員的BackyardID為 '(.*)'")]
        public void Then回傳第個採購人員的BackyardID為(int index, string expected)
        {
            this.GetElement(index).AssertAreEqual("PhrBackyardId", expected);
        }

        [Then(@"回傳第 (.*) 個採購人員的中文名稱為 '(.*)'")]
        public void Then回傳第個採購人員的中文名稱為(int index, string expected)
        {
            this.GetElement(index).AssertAreEqual("PhrFullName", expected);
        }

        [Then(@"回傳第 (.*) 個採購人員的分機為 '(.*)'")]
        public void Then回傳第個採購人員的分機為(int index, string expected)
        {
            this.GetElement(index).AssertAreEqual("PhrExtNumber", expected);
        }

        [Then(@"回傳第 (.*) 個採購人員的Email為 '(.*)'")]
        public void Then回傳第個採購人員的Email為(int index, string expected)
        {
            this.GetElement(index).AssertAreEqual("PhrEmail", expected);
        }

        [Then(@"回傳第 (.*) 個採購主任的BackyardID為 '(.*)'")]
        public void Then回傳第個採購主任的BackyardID為(int index, string expected)
        {
            this.GetElement(index).AssertAreEqual("StaffBackyardId", expected);
        }

        [Then(@"回傳第 (.*) 個採購主任的中文名稱為 '(.*)'")]
        public void Then回傳第個採購主任的中文名稱為(int index, string expected)
        {
            this.GetElement(index).AssertAreEqual("StaffFullName", expected);
        }

        [Then(@"回傳第 (.*) 個採購主任的分機為 '(.*)'")]
        public void Then回傳第個採購主任的分機為(int index, string expected)
        {
            this.GetElement(index).AssertAreEqual("StaffExtNumber", expected);
        }

        [Then(@"回傳第 (.*) 個採購主任的Email為 '(.*)'")]
        public void Then回傳第個採購主任的Email為(int index, string expected)
        {
            this.GetElement(index).AssertAreEqual("StaffEmail", expected);
        }
    }
}
