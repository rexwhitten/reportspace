namespace ReportSpace.CustomerDashboard.Web.ViewModels
{
    using System;

    public class DateTimeReportParameter : ReportParameter<DateTime>
    {
        public DateTimeReportParameter(string displayName, string name)
            : base(displayName, name)
        {
        }

        public DateTimeReportParameter()
        {
        }
    }
}