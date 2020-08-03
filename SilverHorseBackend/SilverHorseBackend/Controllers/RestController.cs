using System;
using System.Net.Http;

namespace SilverHorseBackend.Controllers
{
    public class RestController
    {

        private HttpResponseMessage response = null;

        public enum HttpMethod
        {
            GET,
            POST,
            PUT,
            DELETE,
        }

        // Reference for non static HttpClient memory leak; https://aspnetmonsters.com/2016/08/2016-08-27-httpclientwrong/
        private static HttpClient restClient = new HttpClient();

        public RestMoq MoqResponse
        {
            set
            {
                restClient = new HttpClient(value.createMockHttpMessageHandler().Object);
            }
        }

        public RestController(HttpMessageHandler mockHander = null)
        {
            if (mockHander != null)
            {
                restClient = new HttpClient(mockHander);
            }
        }

        public string handle(HttpMethod method, string uri, string postBody = "")
        {
            string retVal = "";
            var uriObj = new Uri(uri);
            switch (method)
            {
                case HttpMethod.GET:
                    response = restClient.GetAsync(uriObj).Result;
                    break;

                case HttpMethod.POST:
                    response = restClient.PostAsync(uriObj, new StringContent(postBody)).Result;
                    break;

                case HttpMethod.PUT:
                    response = restClient.PutAsync(uriObj, new StringContent(postBody)).Result;
                    break;

                case HttpMethod.DELETE:
                    response = restClient.DeleteAsync(uriObj).Result;
                    break;
            }

            if (response.IsSuccessStatusCode)
            {
                retVal = (response.Content != null) ? response.Content.ReadAsStringAsync().Result : "";
            }
            return retVal;
        }

        /*
         * HttpResponseMessage
         *  - Get response of REST API call
         */
        public HttpResponseMessage getResponse()
        {
            return response;
        }
    }
}