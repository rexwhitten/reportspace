namespace ReportSpace.CustomerDashboard.Web.Controllers
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Mvc;

    using ReportSpace.CustomerDashboard.Core;
    using ReportSpace.CustomerDashboard.Core.QueryableExtensions;

    public class ClientController : Controller
    {
        private readonly IUserContext _usersContext;

        public ClientController(IUserContext usersContext)
        {
            _usersContext = usersContext;
        }

        [Authorize(Roles = "Administrator")]
        public ActionResult Index(string nameFilter = "")
        {
            var clients = _usersContext.Clients.FilterByName(nameFilter).ToList();
                
            return Json(clients, JsonRequestBehavior.AllowGet);
        }
    }
}