using System;
using TechTalk.SpecFlow;
using System.Net.Http;
using System.Collections.Generic;
using Yahoo.Business.Security;
using Newtonsoft.Json.Linq;
using System.Net.Http.Formatting;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace YahooApiSite.AcceptanceTest.網站安全性.使用者權限管理
{
    [Binding]
    public class 取得使用者權限Steps
    {
        private const string BASE_ADDR = "http://localhost:8888";

        HttpClient httpClient;

        int? userId;
        IList<PrivilegeInfo> privileges;

        [Before("HttpClient")]
        public void CreateHttpClient()
        {
            httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri(BASE_ADDR);
        }

        [After("HttpClient")]
        public void DisposeHttpClient()
        {
            httpClient.Dispose();
        }

        [Given(@"使用者編號為 (.*)")]
        public void Given使用者編號為(int p0)
        {
            userId = p0;
        }

        [When(@"獲取權限清單")]
        public void When獲取權限清單()
        {
            var requestContent = new
            {
                userId = userId
            };
            var request = new HttpRequestMessage(HttpMethod.Post, "api/security/AcquirePrivileges");
            request.Content = new ObjectContent(requestContent.GetType(), requestContent, new JsonMediaTypeFormatter());
            var response = httpClient.SendAsync(request).Result;
            var responseContent = response.Content.ReadAsAsync<JObject>().Result;


            var o = responseContent["privileges"];

            //privileges = ((JArray)).Values<PrivilegeInfo>().ToList();
        }

        [Then(@"清單筆數為 (.*)")]
        public void Then清單筆數為(int p0)
        {
            Assert.AreEqual(p0, privileges.Count);
        }

        [Then(@"包含功能編號 (.*)")]
        public void Then包含功能編號(int p0)
        {
            var privilege = privileges.FirstOrDefault(p => p.FunctionId == p0);
            Assert.IsNotNull(privilege);
        }
    }
}
