using System.Diagnostics;
using System.Net.Http;
using System.Threading;

namespace ErpApi.MessageHandlers
{
    /// <summary>
    /// A message handler used to dump request and response informations.
    /// </summary>
    internal class DumpingMessageHandler : MessageProcessingHandler
    {
        /// <summary>
        /// Processes an HTTP request message.
        /// </summary>
        /// <param name="request">The HTTP request message to process.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>
        /// Returns <see cref="T:System.Net.Http.HttpRequestMessage" />.The HTTP request message that was processed.
        /// </returns>
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

        /// <summary>
        /// Processes an HTTP response message.
        /// </summary>
        /// <param name="response">The HTTP response message to process.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>
        /// Returns <see cref="T:System.Net.Http.HttpResponseMessage" />.The HTTP response message that was processed.
        /// </returns>
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