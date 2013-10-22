namespace ReportSpace.CustomerDashboard.Web.Controllers
{
    using System.Web.Mvc;

    using ReportSpace.CustomerDashboard.Web.Services;

    public class ReportParameterController : Controller
    {
        private readonly IReportParametersService _reportParametersService;


        public ReportParameterController(IReportParametersService reportParametersService)
        {
            _reportParametersService = reportParametersService;
        }

        public ActionResult Index(string reportPath, string searchTerm)
        {
            var reportParameters = _reportParametersService.GetParameters(reportPath);

            return View(reportParameters);
        }
    }
}