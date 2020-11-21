using Autofac;
using Autofac.Extras.CommonServiceLocator;
using Autofac.Integration.WebApi;
using CommonServiceLocator;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Serilog;
using Serilog.Formatting.Compact;
using Serilog.Formatting.Json;
using System;
using System.Configuration;
using System.IO;
using System.Net.Http.Formatting;
using System.Reflection;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.ExceptionHandling;
using WebApiTemplate.Infrastructure;
using WebApiTemplate.Infrastructure.Logging;

namespace WebApiTemplate
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            #region CORS

            var origins = ConfigurationManager.AppSettings["Origins"];
            var corsAttr = new EnableCorsAttribute(origins, "*", "*");
            config.EnableCors(corsAttr);

            #endregion CORS

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            #region JSON Configuration

            if (ConfigurationManager.AppSettings["Environment"] != "local")
            {
                var serializerSettings = config.Formatters.JsonFormatter.SerializerSettings;
                serializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
                serializerSettings.Formatting = Formatting.Indented;
            }
            else
            {
                var jsonFormatter = new JsonMediaTypeFormatter();
                var serializerSettings = jsonFormatter.SerializerSettings;

                serializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
                serializerSettings.Formatting = Formatting.Indented;
                jsonFormatter.UseDataContractJsonSerializer = false;
                config.Services.Replace(typeof(IContentNegotiator), new JsonContentNegotiator(jsonFormatter));
            }

            #endregion JSON Configuration

            ConfigureDependencyInjection(config);

            config.Services.Add(typeof(IExceptionLogger), new GlobalExceptionLogger());
        }

        public static void ConfigureDependencyInjection(HttpConfiguration config)
        {

            var builder = new ContainerBuilder();

            // Register your Web API controllers.
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            builder.RegisterModule<AutoFacModule>();

            // OPTIONAL: Register the Autofac filter provider.
            builder.RegisterWebApiFilterProvider(config);

            // OPTIONAL: Register the Autofac model binder provider.
            builder.RegisterWebApiModelBinderProvider();

            // Set the dependency resolver to be Autofac.
            var container = builder.Build();
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);

            var autofacServiceLocator = new AutofacServiceLocator(container);
            ServiceLocator.SetLocatorProvider(() => autofacServiceLocator);
        }
    }
}
