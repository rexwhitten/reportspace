namespace ReportSpace.CustomerDashboard.Web.Controllers
{
    using System.Linq;
    using System.Web.Mvc;
    using System.Web.Security;
    using ReportSpace.CustomerDashboard.Core;
    using ReportSpace.CustomerDashboard.Core.QueryableExtensions;
    using ReportSpace.CustomerDashboard.Web.Controllers.Core;

    public class CategoryController : Controller
    {
        #region [ Fields ]
        private readonly IReportsContext _reportsContext;
        private SSRSContext m_context = new SSRSContext();
        #endregion

        #region [ Constructors ]
        public CategoryController(IReportsContext reportsContext)
        {
            _reportsContext = reportsContext;
        }
        #endregion

        public ActionResult Index(string path = "/")
        {
            // REX: Get a Listing of Folders tom the SSRS Server 
            // Detect the Client, and then Only Paths under that client (SSRS folders should be oriented by user names) 
            if (User.Identity.Name == "root")
            {
                path = "/Client Reports/" + User.Identity.Name;
            }
            else
            {
                path = "/Client Reports/root/" + User.Identity.Name;
            }
            var items = this.m_context.GetCatalog(path);
            

            return this.View(items);
        }

        public ActionResult Display(string path, string display_name)
        {
            string full_report_url = string.Format("~/ReportViewer/Show.aspx?path={0}", path);

            ViewBag.ReportPath = full_report_url;
            ViewBag.Title = display_name;
            ViewBag.Message = path;
            return View();
        }

    }
}