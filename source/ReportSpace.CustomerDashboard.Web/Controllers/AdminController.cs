using System.Web.Mvc;

namespace ReportSpace.CustomerDashboard.Web.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        #region [ Indexes ] 
        [Authorize(Roles = "Administrator")]
        public ActionResult Index()
        {
            return View();
        }
        #endregion
    }
}