using System.Net.Http;
using System.Web;
using System.Web.Http;
using ApiFoundation.Extension.Handlers;
using ApiFoundation.Services;
using System.Web.Mvc;

namespace ErpApi
{
    /// <summary>
    /// WebApiApplication.
    /// </summary>
    public class WebApiApplication : HttpApplication
    {
        /// <summary>
        /// Occurs when application is started.
        /// </summary>
        protected void Application_Start()
        {
            //Bootstrapper.Initialise();

            var config = GlobalConfiguration.Configuration;

            //config.MessageHandlers.Add(new DumpingMessageHandler());
            //var securedHandler = (DelegatingHandler)config.DependencyResolver.GetService(typeof(SecuredContentHandler));
            //config.MessageHandlers.Add(securedHandler);
           
            //config.MessageHandlers.Add(new DumpingMessageHandler());

            config.Routes.MapHttpRoute("DefaultApi", "api/{controller}/{action}");
            config.Filters.Add(new ModelStateActionFilter());

            AreaRegistration.RegisterAllAreas();
        }
    }
}