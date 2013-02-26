using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using System.Net.Http;
using Newtonsoft.Json.Linq;
using System.Net.Http.Formatting;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Net;

namespace YahooApiSite.AcceptanceTest
{
    public class HttpClientStepsBase
    {
        private const string BASE_ADDR = "http://localhost:8888";

        protected HttpResponseMessage Response
        {
            get
            {
                return ScenarioContext.Current["Response"] as HttpResponseMessage;
            }
            private set
            {
                ScenarioContext.Current["Response"] = value;
            }
        }

        protected JObject ResponseContent
        {
            get
            {
                return ScenarioContext.Current["ResponseContent"] as JObject;
            }
            private set
            {
                ScenarioContext.Current["ResponseContent"] = value;
            }
        }

        protected void SendRequest(HttpMethod method, string uri, object requestContent)
        {
            if (HttpClientCommonSteps.HttpClient == null)
            {
                throw new InvalidOperationException();
            }

            var request = new HttpRequestMessage(method, uri);
            request.Content = new ObjectContent(requestContent.GetType(), requestContent, new JsonMediaTypeFormatter());

            Response = HttpClientCommonSteps.HttpClient.SendAsync(request).Result;

            if (Response.IsSuccessStatusCode)
            {
                ResponseContent = Response.Content.ReadAsAsync<JObject>().Result;
            }
        }
    }
}
