using System.Web.Mvc;

namespace ReportSpace.CustomerDashboard.Web.Controllers
{
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;
    using System.Net;
    using System.Web.Security;
    using ReportSpace.CustomerDashboard.Core;
    using ReportSpace.CustomerDashboard.Core.QueryableExtensions;
    using ReportSpace.CustomerDashboard.Web.Filters;
    using ReportSpace.CustomerDashboard.Web.Services;
    using ReportSpace.CustomerDashboard.Web.ViewModels;
    using AutoMapper;
    using Report = ReportSpace.CustomerDashboard.Core.Models.Report;

    /// <summary>
    /// Note: Refactored to directly talk to the Configured SSRS Server
    /// This controller will use the SOAP Client for SSRS
    /// </summary>
    public class ReportController : Controller
    {
        #region [ Fields ]
        private readonly IReportsService _reportsService;

        private readonly IReportsContext _reportsContext;

        private readonly IRoleService _roleService;
        #endregion

        #region [ Constructors ]
        public ReportController(IReportsService reportsService, IReportsContext reportsContext, IRoleService roleService)
        {
            _reportsService = reportsService;
            _reportsContext = reportsContext;
            _roleService = roleService;
        }
        #endregion 

        #region [ Controller Actions ] 
        public ActionResult Index(string categoryName = null)
        {
            // View Bag 
            ViewBag.Title = "Reports";
            ViewBag.Description = categoryName;
            
            // View Model 
            List<ReportViewModel> reportViewModels = new List<ReportViewModel>();
            
            // Assert User Security
            if (User.IsInRole("Administrator"))
            {
                ViewBag.CanAddReports = true;
            }


            return View(reportViewModels);
        }

        public ActionResult Edit(int id)
        {
            Report report = _reportsContext.Reports.Include(r => r.Roles).First(r => r.Id == id);
            LoadReportItems();
            LoadReportCategories();
            ViewBag.DialogTitle = "Edit Report";

            return View(Mapper.Map<ReportViewModel>(report));
        }

        public ActionResult Show(string Path)
        {
            string full_report_url = string.Format("{0}/Reports/Pages/Report.aspx?ItemPath={1}", System.Configuration.ConfigurationManager.AppSettings["ssrs.server"], Path);
            
            ViewBag.ReportPath = Path;
            ViewBag.Description = "Report viewer";

            return View("Show");
        }

        #region Create
        
        [HttpGet]
        public ActionResult New()
        {
            LoadReportItems();
            LoadReportCategories();
            ViewBag.DialogTitle = "New Report";

            return View("Edit", new ReportViewModel());
        }

        [HttpPost]
        public ActionResult Create(ReportViewModel reportViewModel)
        {
            if (!ModelState.IsValid)
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;

                return PartialView("_ValidationSummary", reportViewModel);
            }

            var report = Mapper.Map<Report>(reportViewModel);
            var savedRecords = _reportsContext.SaveChanges();
            EnsureThereIsOnlyOneDefaultReport(report);

            return View("ReportTableItem", Mapper.Map<ReportViewModel>(report));
        }

        [HttpPut]
        public ActionResult Update(int id, ReportViewModel reportViewModel)
        {
            var report = Mapper.Map<Report>(reportViewModel);
            var savedItems = _reportsContext.SaveChanges();
            EnsureThereIsOnlyOneDefaultReport(report);
            if (User.IsInRole("Administrator"))
            {
                ViewBag.CanAddReports = true;
            }

            return View(
                savedItems != 0
                ? "ReportTableItem"
                : "Edit", 
                Mapper.Map<ReportViewModel>(report));
        }

        private void EnsureThereIsOnlyOneDefaultReport(Report report)
        {
            if (report.IsDefault)
            {
                this._reportsContext.ResetPreviousDefaultReport(report.Id);
                this._reportsContext.SaveChanges();
            }
        }

        #endregion

        #region Delete

        [HttpDelete]
        public ActionResult Delete(int id)
        {
            var toDelete = _reportsContext.Reports.GetWithRoles(id);
            _reportsContext.Reports.Remove(toDelete);
            _reportsContext.SaveChanges();

            return Json(toDelete);
        }

        #endregion

        public ActionResult Search(string searchTerm)
        {
            var defaultReport = _reportsContext.Reports.FilterByUserRoles(Roles.GetRolesForUser()).FirstOrDefault(r => r.IsDefault);
            if (defaultReport != null)
            {
                return RedirectToAction("Show", new { id = defaultReport.Id, searchTerm = searchTerm });
            }

            return new HttpNotFoundResult();
        }
        #endregion

        #region Private methods

        private void LoadReportItems()
        {
            var reportItems = new SelectList(_reportsService.GetAll(), "Path", "Name");
            ViewBag.ReportItems = reportItems;
        }

        private void LoadReportCategories()
        {
            // REX: Refactored to Acutally just pull the Listing of Folders on the SSRS Server. 
            var categories = new List<string> { "Standard" };

            ViewBag.Categories = new SelectList(categories.Select(x => new { Value = x, Text = x }), "Value", "Text");
        }

        #endregion
    }
}
