namespace ReportSpace.CustomerDashboard.Web.ViewModels
{
    using System.Collections.Generic;
    using System.Linq;

    public class StringReportParameter : ReportParameter<string>, IStringReportParameter
    {
        public IList<string> ValidValues { get; set; }

        public bool DisplayAsDropDown
        {
            get
            {
                return ValidValues != null && ValidValues.Any();
            }
        }

        public StringReportParameter(string displayName, string name)
            : base(displayName, name)
        {
            ValidValues = new List<string>();
        }
    }
}