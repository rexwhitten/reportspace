using System.Web.Mvc;
using System.Web.Routing;

namespace ReportSpace.CustomerDashboard.Web
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.IgnoreRoute("{resource}.aspx/{*pathInfo}");
            routes.AppendTrailingSlash = false;

            routes.MapRoute(
                "Default", 
                "{controller}/{action}/{id}", 
                new
                    {
                        controller = "Category", 
                        action = UrlParameter.Optional, 
                        id = UrlParameter.Optional
                    });
        }
    }
}