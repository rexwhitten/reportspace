namespace ReportSpace.CustomerDashboard.Web.Factories
{
    using ReportSpace.CustomerDashboard.Web.ViewModels;

    using Microsoft.Reporting.WebForms;

    public interface IReportParameterFactory
    {
        IReportParameter Create(ReportParameterInfo reportParameterInfo);
    }
}