using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using System.Net.Http;
using System.Net;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace YahooApiSite.AcceptanceTest
{
    [Binding]
    public class HttpClientCommonSteps
    {
        private const string BASE_ADDR = "http://localhost:8888";

        public static HttpClient HttpClient
        {
            get
            {
                return ScenarioContext.Current["HttpClient"] as HttpClient;
            }
            private set
            {
                ScenarioContext.Current["HttpClient"] = value;
            }
        }

        public static HttpResponseMessage Response
        {
            get
            {
                return ScenarioContext.Current["Response"] as HttpResponseMessage;
            }
        }

        [Before("HttpClient")]
        public void CreateHttpClient()
        {
            HttpClient = new HttpClient();
            HttpClient.BaseAddress = new Uri(BASE_ADDR);
        }

        [After("HttpClient")]
        public void DisposeHttpClient()
        {
            HttpClient.Dispose();
        }

        [Then(@"回傳成功狀態")]
        public void Then回傳成功狀態()
        {
            if (!Response.IsSuccessStatusCode)
            {
                var errorContent = Response.Content.ReadAsStringAsync().Result;
                Assert.IsTrue(Response.IsSuccessStatusCode, errorContent);
            }
        }

        [Then(@"回傳狀態為 ""(.*)""")]
        public void Then回傳狀態為(HttpStatusCode p0)
        {
            Assert.AreEqual(p0, Response.StatusCode);
        }
    }
}
