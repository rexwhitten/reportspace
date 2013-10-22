namespace ReportSpace.CustomerDashboard.Web.ViewModels
{
    public class BooleanReportParameter : ReportParameter<bool>
    {
        public BooleanReportParameter(string displayName, string name)
            : base(displayName, name)
        {
        }
    }
}