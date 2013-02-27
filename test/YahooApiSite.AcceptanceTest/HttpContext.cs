using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json.Linq;
using System.Net.Http;
using System.Net;
using System.Net.Http.Formatting;

namespace Yahoo
{
    public class HttpContext
    {
        const string BASE_ADDRESS = "http://localhost:8888";

        public JObject RequestContent { get; set; }

        public bool IsSuccess { get; private set; }
        public HttpStatusCode StatusCode { get; private set; }
        public JObject ResponseContent { get; private set; }
        public string ErrorMessage { get; private set; }

        public void Send(HttpMethod method, string uri)
        {
            using (var httpClient = new HttpClient())
            {
                httpClient.BaseAddress = new Uri(BASE_ADDRESS);

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
