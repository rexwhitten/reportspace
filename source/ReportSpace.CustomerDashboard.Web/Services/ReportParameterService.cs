namespace ReportSpace.CustomerDashboard.Web.Services
{
    using System.Collections.Generic;
    using System.Linq;

    using ReportSpace.CustomerDashboard.Web.Factories;
    using ReportSpace.CustomerDashboard.Web.ViewModels;

    public class ReportParameterService : IReportParametersService
    {
        private readonly IReportsService _reportsService;

        private readonly IReportParameterFactory _reportParameterFactory;

        public ReportParameterService(IReportsService reportsService, IReportParameterFactory reportParameterFactory)
        {
            this._reportsService = reportsService;
            this._reportParameterFactory = reportParameterFactory;
        }

        public IList<IReportParameter> GetParameters(string reportPath)
        {
            var serverReport = _reportsService.GetReport(reportPath);

            var parameters = serverReport.GetParameters()
                                         .Where(p => p.PromptUser && !string.IsNullOrEmpty(p.Prompt))
                                         .Select(_reportParameterFactory.Create)
                                         .ToList();

            return parameters;
        }
    }
}