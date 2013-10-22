namespace ReportSpace.CustomerDashboard.Web.Services
{
    using System;
    using System.Collections.Generic;
    using System.Configuration;
    using System.IO;
    using System.Linq;

    using ReportSpace.CustomerDashboard.Web.Factories;

    using Microsoft.Reporting.WebForms;

    using Ninject;

    using ReportingService2010;

    public class ReportsService : IReportsService
    {
        private readonly ReportingService2010 _reportingService;

        [Inject]
        public IReportParameterFactory ReportParameterFactory { get; set; }

        public static string ServerUrl;

        public ReportsService()
        {
            _reportingService = new ReportingService2010 { Credentials = System.Net.CredentialCache.DefaultCredentials };
            ServerUrl = ConfigurationManager.AppSettings["ReportServerUrl"];
        }

        public IList<ReportItem> GetAll()
        {
            var items = _reportingService.ListChildren("/", true).ToList();
            var result = items.Where(i => i.TypeName == "Report").Select(i => new ReportItem { Name = i.Name, Path = i.Path }).ToList();

            return result;
        }

        public bool Exists(string reportPath)
        {
            var reportFolder = Path.GetDirectoryName(reportPath).Replace("\\", "/");
            var reportName = Path.GetFileName(reportPath);
            return _reportingService.ListChildren(reportFolder, false).ToList().Any(c => c.Name == reportName);
        }

        public ServerReport GetReport(string reportPath)
        {
            return new ServerReport
                       {
                           ReportServerUrl = new Uri(ServerUrl),
                           ReportPath = reportPath
                       };
        }
    }
}