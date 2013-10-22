namespace ReportSpace.CustomerDashboard.Web.Services
{
    using System.Collections.Generic;

    using Microsoft.Reporting.WebForms;

    public interface IReportsService
    {
        IList<ReportItem> GetAll();

        bool Exists(string reportPath);

        ServerReport GetReport(string reportPath);
    }
}