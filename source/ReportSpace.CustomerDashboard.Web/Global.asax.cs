using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace ReportSpace.CustomerDashboard.Web
{
    using ReportSpace.CustomerDashboard.Web.App_Start;

    public class MvcApplication : HttpApplication
    {
        #region [ Constructors ]
        public MvcApplication()
            : base()
        {

        }
        #endregion



        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            AuthConfig.RegisterAuth();
            MappingConfig.RegisterMaps();
        }
    }
}