namespace ReportSpace.CustomerDashboard.Web.Controllers
{
    using System.Data.Entity;
    using System.Linq;
    using System.Web.Mvc;

    using ReportSpace.CustomerDashboard.Core;
    using ReportSpace.CustomerDashboard.Core.Models;
    using ReportSpace.CustomerDashboard.Core.QueryableExtensions;

    public class RoleController : ApplicationController
    {
        private readonly IUserContext _userContext;

        public RoleController(IUserContext userContext)
        {
            _userContext = userContext;
        }

        [Authorize(Roles = "Administrator")]
        public ActionResult Index(string nameFilter = "")
        {
            var roles = _userContext.Roles.Include(r => r.UserProfiles).FilterByName(nameFilter).ToList();
            return RespondTo(
                format =>
                    {
                        format.Html = () => View(roles);
                        format.Json = () => Json(roles.Select(r => new { r.Id, r.Name }), JsonRequestBehavior.AllowGet);
                    });
        }

        [Authorize(Roles="Administrator")]
        public ActionResult New()
        {
            var role = _userContext.Roles.Create();
            ViewBag.DialogTitle = "Create Role";

            return View("Edit", role);
        }

        [Authorize(Roles = "Administrator")]
        public ActionResult Edit(int id)
        {
            Role role = _userContext.Roles.Find(id);
            ViewBag.DialogTitle = "Edit Role";

            return View(role);
        }

        [Authorize(Roles = "Administrator")]
        public ActionResult Create(Role role)
        {
            _userContext.Roles.Add(role);
            _userContext.SaveChanges();

            return PartialView("_Role", role);
        }

        [Authorize(Roles = "Administrator")]
        public ActionResult Update(int id, Role role)
        {
            var databaseRole = _userContext.Roles.Find(id);

            if (TryUpdateModel(databaseRole, string.Empty, null, new[] { "UserProfiles" }))
            {
                _userContext.SaveChanges();
                
                return View("_Role", databaseRole);
            }

            return View("Edit", databaseRole);
        }

        [Authorize(Roles = "Administrator")]
        public ActionResult Destroy(int id)
        {
            var role = _userContext.Roles.Find(id);
            role.UserProfiles.Clear();
            _userContext.Roles.Remove(role);

            _userContext.SaveChanges();

            return Json(role);
        }
    }
}