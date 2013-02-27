using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Http;
using Newtonsoft.Json.Linq;
using System.Net.Http.Formatting;

namespace Yahoo
{
    static class HttpHelper
    {
        public static HttpResponseMessage GetResponse(string baseAddress, HttpMethod method, string uri, JObject requestContent)
        {
            using (var httpClient = new HttpClient())
            {
                httpClient.BaseAddress = new Uri(baseAddress);

                var request = new HttpRequestMessage(method, uri);
                request.Content = new ObjectContent(requestContent.GetType(), requestContent, new JsonMediaTypeFormatter());

                var response = httpClient.SendAsync(request).Result;
                return response;
            }
        }
    }
}
