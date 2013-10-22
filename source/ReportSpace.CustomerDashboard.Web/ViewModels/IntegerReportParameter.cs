namespace ReportSpace.CustomerDashboard.Web.ViewModels
{
    public class IntegerReportParameter : ReportParameter<int>
    {
        public IntegerReportParameter(string displayName, string name)
            : base(displayName, name)
        {
        }
    }
}