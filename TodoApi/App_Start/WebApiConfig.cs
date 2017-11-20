using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using Microsoft.Owin.Cors;
using Newtonsoft.Json.Serialization;
using Owin;
using SimpleInjector.Integration.WebApi;

namespace TodoApi.App_Start
{
    public class WebApiConfig
    {
        public static void Configure(IAppBuilder app)
        {


            HttpConfiguration config = new HttpConfiguration();

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            config.Formatters.Remove(config.Formatters.XmlFormatter);

            app.UseCors(CorsOptions.AllowAll);

            config.Formatters.JsonFormatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            config.Formatters.JsonFormatter.UseDataContractJsonSerializer = false;

            config.DependencyResolver = new SimpleInjectorWebApiDependencyResolver(SimpleInjectorInitializer.Container);

            app.UseWebApi(config);
        }
    }
}