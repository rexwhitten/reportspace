namespace ReportSpace.CustomerDashboard.Web.Converters
{
    using System.Linq;

    using ReportSpace.CustomerDashboard.Core.Models;
    using ReportSpace.CustomerDashboard.Web.ViewModels;

    using AutoMapper;

    public class ReportToReportViewModelConverter : TypeConverter<Report, ReportViewModel>
    {
        protected override ReportViewModel ConvertCore(Report source)
        {
            var destination = new ReportViewModel
                                  {
                                      Id = source.Id,
                                      Path = source.Path,
                                      Name = source.Name,
                                      Description = source.Description,
                                      Category = source.Category,
                                      OpensOnSearch = source.IsDefault,
                                      IsHidden = source.IsHidden,
                                      Roles = string.Join(",", source.Roles.Select(r => string.Format("{0};{1}", r.Id, r.Name)).ToArray())
                                  };

            return destination;
        }
    }
}