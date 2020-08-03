using Moq;
using Moq.Protected;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SilverHorseBackend.Controllers
{
    public class RestMoq
    {

        private System.Net.HttpStatusCode statusCode;
        private string JsonString;

        public RestMoq(System.Net.HttpStatusCode status, string returnJson)
        {
            statusCode = status;
            JsonString = returnJson;
        }

        /// <summary>
        /// Lifted verbatum from https://gingter.org/2018/07/26/how-to-mock-httpclient-in-your-net-c-unit-tests/
        /// </summary>
        /// <param name="status">Status code E.G. 200 Ok</param>
        /// <param name="valueToReturn">JSON string to be returned from the HttpClient REST call</param>
        /// <returns></returns>
        public Mock<HttpMessageHandler> createMockHttpMessageHandler()
        {
            var handlerMock = new Mock<HttpMessageHandler>(MockBehavior.Strict);
            handlerMock
                .Protected()
                .Setup<Task<HttpResponseMessage>>(
                  "SendAsync",
                  ItExpr.IsAny<HttpRequestMessage>(),
                  ItExpr.IsAny<CancellationToken>())
                .ReturnsAsync(new HttpResponseMessage()
                {
                    StatusCode = statusCode,
                    Content = new StringContent(JsonString),
                })
                .Verifiable();

            return handlerMock;
        }
    }
}
