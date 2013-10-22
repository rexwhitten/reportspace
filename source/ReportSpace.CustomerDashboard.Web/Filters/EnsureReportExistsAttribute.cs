namespace ReportSpace.CustomerDashboard.Web.Filters
{
    using System;
    using System.Linq;
    using System.Net;
    using System.Web.Mvc;

    using ReportSpace.CustomerDashboard.Core;
    using ReportSpace.CustomerDashboard.Web.Services;

    using Ninject;

    public class EnsureReportExistsAttribute : ActionFilterAttribute
    {
        [Inject]
        public IReportsContext ReportsContext { get; set; }

        [Inject]
        public IReportsService ReportsService { get; set; }

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var id = Convert.ToInt32(filterContext.ActionParameters["id"]);
            var report = ReportsContext.Reports.First(r => r.Id == id);

            if (!ReportsService.Exists(report.Path))
            {
                filterContext.RequestContext.HttpContext.Response.StatusCode = (int)HttpStatusCode.NotFound;
                
                var actionResult = new ViewResult { ViewName = "Error" };
                actionResult.ViewBag.Title = "Not found";
                actionResult.ViewBag.Description = "It seems that the requested report does not exist on the Reporting Service";
                
                filterContext.Result = actionResult;
            }
        }
    }
}