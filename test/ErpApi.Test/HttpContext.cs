using System;
using System.Diagnostics;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Threading;
using Newtonsoft.Json.Linq;

namespace ErpApi.Test
{
    /// <summary>
    /// 處理 HttpClient 收發相關事務。
    /// </summary>
    public class HttpContext
    {
        private readonly string _baseAddress = "http://localhost:8888";

        private readonly JObject _requestContent;

        public HttpContext()
        {
            _requestContent = new JObject();
        }

        public bool IsSuccess { get; private set; }

        public HttpStatusCode StatusCode { get; private set; }

        public JObject ResponseContent { get; private set; }

        public string ErrorMessage { get; private set; }

        /// <summary>
        /// 設定 request content 中欄位 property name 的值。
        /// </summary>
        /// <param name="propertyName">Name of the property.</param>
        /// <param name="content">The value.</param>
        public void SetRequestValue(string propertyName, object content)
        {
            this._requestContent.Add(new JProperty(propertyName, content));
        }

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

                if (_requestContent != null)
                {
                    request.Content = new ObjectContent(_requestContent.GetType(), _requestContent, new JsonMediaTypeFormatter());
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