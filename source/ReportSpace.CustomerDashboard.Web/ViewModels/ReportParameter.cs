namespace ReportSpace.CustomerDashboard.Web.ViewModels
{
    public abstract class ReportParameter<T> : IReportParameter
    {
        protected ReportParameter()
        {
        }

        protected ReportParameter(string displayName, string name)
        {
            this.Key = name;
            DisplayName = displayName;
        }

        public string Key { get; set; }

        public bool AllowMultipleValues { get; set; }

        public string DisplayName { get; private set; }

        public T Value { get; set; }
    }
}