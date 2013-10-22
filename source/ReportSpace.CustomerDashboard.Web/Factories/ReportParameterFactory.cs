namespace ReportSpace.CustomerDashboard.Web.Factories
{
    using System;
    using System.Globalization;
    using System.Linq;

    using ReportSpace.CustomerDashboard.Web.ViewModels;

    using Microsoft.Reporting.WebForms;

    public class ReportParameterFactory : IReportParameterFactory
    {
        public IReportParameter Create(ReportParameterInfo reportParameterInfo)
        {
            IReportParameter result;
            switch (reportParameterInfo.DataType)
            {
                case ParameterDataType.Boolean:
                    result = CreateBooleanParameter(reportParameterInfo);
                    break;
                case ParameterDataType.DateTime:
                    result = CreateDateTimeParameter(reportParameterInfo);
                    break;
                case ParameterDataType.Float:
                    result = CreateFloatParameter(reportParameterInfo);
                    break;
                case ParameterDataType.Integer:
                    result = CreateIntegerParameter(reportParameterInfo);
                    break;
                default:
                    result = CreateStringParameter(reportParameterInfo);
                    break;
            }

            return result;
        }

        private static IReportParameter CreateStringParameter(ReportParameterInfo reportParameterInfo)
        {
            var stringReportParameter = new StringReportParameter(reportParameterInfo.Prompt, reportParameterInfo.Name)
                                            {
                                                AllowMultipleValues = reportParameterInfo.MultiValue
                                            };

            if (reportParameterInfo.ValidValues != null && reportParameterInfo.ValidValues.Any())
            {
                stringReportParameter.ValidValues = reportParameterInfo.ValidValues.Select(v => v.Value).ToList();
            }

            if (reportParameterInfo.Values != null && reportParameterInfo.Values.Any())
            {
                stringReportParameter.Value = reportParameterInfo.Values.First();
            }

            return stringReportParameter;
        }

        private static IReportParameter CreateIntegerParameter(ReportParameterInfo reportParameterInfo)
        {
            return new IntegerReportParameter(reportParameterInfo.Prompt, reportParameterInfo.Name);
        }

        private static IReportParameter CreateFloatParameter(ReportParameterInfo reportParameterInfo)
        {
            return new FloatReportParameter(reportParameterInfo.Prompt, reportParameterInfo.Name);
        }

        private static IReportParameter CreateDateTimeParameter(ReportParameterInfo reportParameterInfo)
        {
            var dateTimeReportParameter = new DateTimeReportParameter(reportParameterInfo.Prompt, reportParameterInfo.Name);
            if (reportParameterInfo.Values.Any())
            {
                dateTimeReportParameter.Value = Convert.ToDateTime(
                    reportParameterInfo.Values.First(), new DateTimeFormatInfo { ShortDatePattern = "MM/dd/yyyy" });
            }

            return dateTimeReportParameter;
        }

        private static IReportParameter CreateBooleanParameter(ReportParameterInfo reportParameterInfo)
        {
            return new BooleanReportParameter(reportParameterInfo.Prompt, reportParameterInfo.Name);
        }
    }
}