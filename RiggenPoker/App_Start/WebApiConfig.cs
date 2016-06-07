using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace RiggenPoker
{
    public static class WebApiConfig
    {   //This is for routing the incoming api requests 
        public static void Register(HttpConfiguration config)
        {
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
