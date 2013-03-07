using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Http;
using System.Diagnostics;
using System.Threading;

namespace ErpApi.Test
{
    internal class DumpingMessageHandler : MessageProcessingHandler
    {
        protected override HttpRequestMessage ProcessRequest(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            Trace.WriteLine(request.Content.ReadAsStringAsync().Result);
            return request;
        }

        protected override HttpResponseMessage ProcessResponse(HttpResponseMessage response, CancellationToken cancellationToken)
        {
            Trace.WriteLine(response.Content.ReadAsStringAsync().Result);
            return response;
        }
    }
}
