namespace ReportSpace.CustomerDashboard.Web.ViewModels
{
    using System.Collections.Generic;

    public interface IStringReportParameter : IReportParameter
    {
        IList<string> ValidValues { get; set; }
    }
}