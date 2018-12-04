using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Formatting;
using System.Web;
using System.Web.Http;
using Newtonsoft.Json;

namespace carbon_calculator.App_Start
{
    public class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // TODO: Add any additional configuration code.

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            // WebAPI when dealing with JSON & JavaScript!
            // Setup json serialization to serialize classes to camel (std. Json format)
            config.Formatters.Clear();

            var jsonFromatter = new JsonMediaTypeFormatter();

            jsonFromatter.SerializerSettings.ReferenceLoopHandling = 
                ReferenceLoopHandling.Ignore;

            config.Formatters.Add(jsonFromatter);

        }
    }
}