using System.Web;
using System.Web.Http;
using ErpApi.Filters;

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
            var config = GlobalConfiguration.Configuration;
            config.Routes.MapHttpRoute("DefaultApi", "api/{controller}/{action}");
            config.Filters.Add(new ModelStateActionFilter());
        }
    }
}