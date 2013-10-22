namespace ReportSpace.CustomerDashboard.Web.ViewModels
{
    public interface IReportParameter
    {
        string DisplayName { get; }

        string Key { get; set; }

        bool AllowMultipleValues { get; set; }
    }
}