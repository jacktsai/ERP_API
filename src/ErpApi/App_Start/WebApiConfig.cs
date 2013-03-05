using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using ErpApi.Filters;

namespace ErpApi
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.Routes.MapHttpRoute("DefaultApi", "api/{controller}/{action}");
            config.Filters.Add(new ModelStateActionFilter());
        }
    }
}
