using System.Diagnostics;
using System.Net.Http;
using System.Threading;

namespace ErpApi.MessageHandlers
{
    internal class DumpingMessageHandler : MessageProcessingHandler
    {
        protected override HttpRequestMessage ProcessRequest(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            Trace.WriteLine(string.Format("Request URI: {0}", request.RequestUri));

            var content = request.Content;
            if (content != null)
            {
                Trace.WriteLine(string.Format("Request Content: {0}", content.ReadAsStringAsync().Result));
            }

            return request;
        }

        protected override HttpResponseMessage ProcessResponse(HttpResponseMessage response, CancellationToken cancellationToken)
        {
            var content = response.Content;
            if (content != null)
            {
                Trace.WriteLine(string.Format("Response Content: {0}", content.ReadAsStringAsync().Result));
            }

            return response;
        }
    }
}