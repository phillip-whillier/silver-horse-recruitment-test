using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using SilverHorseBackend.App_Start;

namespace SilverHorseBackend
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            config.Routes.MapHttpRoute(
                name: "CollectionApi",
                routeTemplate: "api/collection",
                defaults: new { }
            );

            config.Filters.Add(new AuthoriseAttribute());
        }
    }
}
