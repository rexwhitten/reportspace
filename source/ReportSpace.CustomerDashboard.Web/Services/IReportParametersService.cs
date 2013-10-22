namespace ReportSpace.CustomerDashboard.Web.Services
{
    using System.Collections.Generic;

    using ReportSpace.CustomerDashboard.Web.ViewModels;

    public interface IReportParametersService
    {
        IList<IReportParameter> GetParameters(string reportPath);
    }
}