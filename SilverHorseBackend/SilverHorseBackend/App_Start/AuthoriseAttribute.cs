using System.Configuration;
using System.Net;
using System.Net.Http;
using System.Security.Principal;
using System.Threading;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace SilverHorseBackend.App_Start
{
    class AuthoriseAttribute : AuthorizationFilterAttribute
    {
        /*
         * OnAuthentication custom authorisation
         * ref: https://www.c-sharpcorner.com/article/basic-authentication-in-web-api/
         */
        public override void OnAuthorization(HttpActionContext actionContext)
        {
            var auth = actionContext.Request.Headers.Authorization;

            if (auth != null && auth.Scheme == "Bearer" && auth.Parameter == ConfigurationManager.AppSettings["bearer"])
            {
                // setting current principle 
                Thread.CurrentPrincipal = new GenericPrincipal(new GenericIdentity("ApiUser"), null);
            }
            else
            {
                actionContext.Response = new HttpResponseMessage(HttpStatusCode.NotImplemented);
            }
        }
    }
}