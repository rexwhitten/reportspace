namespace ReportSpace.CustomerDashboard.Web.Converters
{
    using System.Data.Entity;
    using System.Linq;

    using ReportSpace.CustomerDashboard.Core;
    using ReportSpace.CustomerDashboard.Core.Models;
    using ReportSpace.CustomerDashboard.Core.QueryableExtensions;
    using ReportSpace.CustomerDashboard.Web.ViewModels;

    using AutoMapper;

    public class ReportViewModelToReportConverter : TypeConverter<ReportViewModel, Report>
    {
        private readonly IReportsContext _reportsContext;

        public ReportViewModelToReportConverter(IReportsContext reportsContext)
        {
            _reportsContext = reportsContext;
        }

        protected override Report ConvertCore(ReportViewModel source)
        {
            Report destination;
            if (source.Id != 0)
            {
                destination = this._reportsContext.Reports.Include(r => r.Roles).First(r => r.Id == source.Id);
            }
            else
            {
                destination = this._reportsContext.Reports.Create();
                _reportsContext.Reports.Add(destination);
            }
            
            destination.Name = source.Name;
            destination.Description = source.Description;
            destination.Path = source.Path;
            destination.Category = source.Category;
            destination.IsDefault = source.OpensOnSearch;
            destination.IsHidden = source.IsHidden;
            destination.Roles = _reportsContext.Roles.FilterByListOfIds(source.RoleIds).ToList();

            return destination;
        }
    }
}