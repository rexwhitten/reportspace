namespace ReportSpace.CustomerDashboard.Web.ReportViewer
{
    using System;
    using System.Collections.Generic;
    using System.Configuration;
    using System.Linq;
    using System.Web;

    using ReportSpace.CustomerDashboard.Web.Services;

    using Microsoft.Reporting.WebForms;

    using Ninject;

    public partial class Show : Ninject.Web.PageBase
    {
        [Inject]
        public IReportsService ReportsService { get; set; }

        public string GetReportPath()
        {
            return string.Format("{0}", this.Request["reportPath"]);
        }

        protected void Page_Init()
        {
            var serverReport = this.mainReportViewer.ServerReport;
            serverReport.ReportServerUrl = new Uri(ConfigurationManager.AppSettings["ssrs.server.url"]);
            serverReport.ReportPath = Request.QueryString["path"];

            serverReport.Refresh();
        }

        private IEnumerable<ReportParameter> GetReportParameters(ServerReport serverReport)
        {
            var serverParameters = serverReport.GetParameters();
            var parameterNames = serverParameters.Select(p => p.Name);
            return (from
                        string key
                        in this.Request.Params.Keys
                    let parameterValue = HttpUtility.UrlDecode(Request.Params[key])
                    let serverParameter = serverParameters[key]
                    where 
                        parameterNames.Contains(key)
                    select serverParameter.MultiValue 
                        ? new ReportParameter(key, parameterValue.Split(',')) 
                        : new ReportParameter(key, parameterValue))
                    .ToList();
        }
    }
}