using System.Web;
using System.Web.Mvc;
using Yahoo.Filters;

namespace Yahoo
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}