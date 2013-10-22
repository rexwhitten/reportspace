using System.Web.Mvc;

namespace ReportSpace.CustomerDashboard.Web.Controllers
{
    public class SearchController : Controller
    {
        //
        // GET: /Search/

        public ActionResult New()
        {
            return View();
        }

        public ActionResult Create(string searchTerm)
        {
            return RedirectToAction("Search", "Report", new { searchTerm = searchTerm });
        }
    }
}
