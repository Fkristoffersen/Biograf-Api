using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

//For changing the api respone to json
//using System.Net.Http.Headers;
//Enable communication between domains
using System.Web.Http.Cors;

namespace Biograf_Api
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            // New code
            //config.EnableCors(new EnableCorsAttribute("http://localhost:62272", headers: "*", methods: "*"));
            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

       



            
            //Add this to format to JASON, then change the method.
            //config.Formatters.JsonFormatter.SupportedMediaTypes.Add(new MediaTypeHeaderValue("text/html"));
            //Enable communication, If you want a specific domian, change the * to a domain.
            config.EnableCors(new EnableCorsAttribute("*", "*", "*"));
             
        }
    }
}
