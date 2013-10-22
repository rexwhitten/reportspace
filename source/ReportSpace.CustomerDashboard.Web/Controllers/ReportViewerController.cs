namespace ReportSpace.CustomerDashboard.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;

    using ReportSpace.CustomerDashboard.Core;
    using ReportSpace.CustomerDashboard.Web.Services;

    public class ReportViewerController : Controller
    {
        private readonly IUserContext _userContext;

        private readonly IRoleService _roleService;

        public ReportViewerController(IUserContext userContext, IRoleService roleService)
        {
            _userContext = userContext;
            _roleService = roleService;
        }

        public ActionResult Show(string reportPath, string searchTerm)
        {
            ViewBag.ReportUrl = reportPath;

            return View();
        }

        public ActionResult Refresh(string reportPath, string searchTerm, IDictionary<string, string> reportParameters)
        {
            ViewBag.ReportUrl = string.Format(
                "../ReportViewer/Show.aspx?{0}",
                GetReportParametersUrl(reportPath, searchTerm, reportParameters));

            return View("Show");
        }

        private static string AddParametersFromRequest(IEnumerable<KeyValuePair<string, string>> reportParameters, string reportParametersUrl)
        {
            if (reportParameters != null)
            {
                reportParametersUrl = string.Concat(
                    reportParametersUrl,
                    "&",
                    reportParameters.Where(rp => rp.Key.ToLower() != "clientno").Where(rp => rp.Value != string.Empty).Select(
                        rp => string.Format("{0}={1}", HttpUtility.UrlEncode(rp.Key), HttpUtility.UrlEncode(rp.Value)))
                                    .Aggregate((curr, next) => curr + '&' + next));
            }

            return reportParametersUrl;
        }

        private string GetReportParametersUrl(string reportPath, string searchTerm, IDictionary<string, string> reportParameters = null)
        {
            var reportParametersUrl = string.Format("reportPath={0}", reportPath);
            reportParametersUrl = AddClientIdsParameter(reportParametersUrl, reportParameters);

            reportParametersUrl = AddSearchParameter(reportParametersUrl, searchTerm);

            reportParametersUrl = AddParametersFromRequest(reportParameters, reportParametersUrl);

            return reportParametersUrl;
        }

        private string AddSearchParameter(string reportParametersUrl, string searchTerm)
        {
            if (!string.IsNullOrEmpty(searchTerm))
            {
                reportParametersUrl = string.Concat(reportParametersUrl, "&", string.Format("Fileno={0}", searchTerm));
            }

            return reportParametersUrl;
        }

        private string AddClientIdsParameter(string reportParametersUrl, IDictionary<string, string> reportParameters)
        {
            IList<int> clientIds = _userContext.UserProfiles.Include(up => up.Clients)
                .First(up => up.UserName == User.Identity.Name)
                .Clients
                .Select(c => c.Id)
                .ToList();

            clientIds = FilterClientIdsFromRequestToTheOnesThatTheUserHasAccessTo(reportParameters, clientIds);
            
            if (clientIds.Any())
            {
                var clientNoParameterString = string.Format("ClientNo={0}", string.Join(",", clientIds));
                reportParametersUrl = string.Concat(reportParametersUrl, "&", clientNoParameterString);
            }

            return reportParametersUrl;
        }

        private IList<int> FilterClientIdsFromRequestToTheOnesThatTheUserHasAccessTo(
            IDictionary<string, string> reportParameters, IList<int> clientIds)
        {
            var filteredClientIds = clientIds;
            
            if (reportParameters != null && reportParameters.ContainsKey("ClientNo"))
            {
                var clientIdsFromRequest = reportParameters["ClientNo"].Split(',').ToList()
                    .Select(id => Convert.ToInt32(id)).ToList();
                if (_roleService.IsCurrentUserInRole("Administrator"))
                {
                    filteredClientIds = clientIdsFromRequest;
                }
                else
                {
                    if (clientIdsFromRequest.Any(id => filteredClientIds.Contains(id)))
                    {
                        filteredClientIds = clientIdsFromRequest.Intersect(clientIds).ToList();
                    }
                }
            }

            return filteredClientIds;
        }
    }
}