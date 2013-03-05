using System;
using System.Diagnostics;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Threading;
using Newtonsoft.Json.Linq;

namespace ErpApi.AcceptanceTest
{
    /// <summary>
    /// 處理 HttpClient 收發相關事務。
    /// </summary>
    public class HttpContext
    {
        private readonly string _baseAddress = "http://localhost:8888";

        public HttpContext()
        {
            RequestContent = new JObject();
        }

        public JObject RequestContent { get; private set; }

        public bool IsSuccess { get; private set; }

        public HttpStatusCode StatusCode { get; private set; }

        public JObject ResponseContent { get; private set; }

        public string ErrorMessage { get; private set; }

        public void Send(HttpMethod method, string uri)
        {
            var handler = new DumpingMessageHandler
            {
                InnerHandler = new HttpClientHandler()
            };

            using (var httpClient = new HttpClient(handler))
            {
                httpClient.BaseAddress = new Uri(_baseAddress);

                var request = new HttpRequestMessage(method, uri);

                if (RequestContent != null)
                {
                    request.Content = new ObjectContent(RequestContent.GetType(), RequestContent, new JsonMediaTypeFormatter());
                }

                var response = httpClient.SendAsync(request).Result;

                IsSuccess = response.IsSuccessStatusCode;
                StatusCode = response.StatusCode;

                if (response.Content != null)
                {
                    if (response.IsSuccessStatusCode)
                    {
                        ResponseContent = response.Content.ReadAsAsync<JObject>().Result;
                    }
                    else
                    {
                        ErrorMessage = response.Content.ReadAsStringAsync().Result;
                    }
                }
            }
        }
    }
}