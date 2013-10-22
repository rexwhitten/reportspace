namespace ReportSpace.CustomerDashboard.Web.App_Start
{
    using System.Web.Mvc;

    using ReportSpace.CustomerDashboard.Core.Models;
    using ReportSpace.CustomerDashboard.Web.Converters;
    using ReportSpace.CustomerDashboard.Web.ViewModels;

    using AutoMapper;

    public class MappingConfig
    {
         public static void RegisterMaps()
         {
             Mapper.Initialize(config => config.ConstructServicesUsing(t => DependencyResolver.Current.GetService(t)));
             Mapper.CreateMap<UserProfileViewModel, UserProfile>().ConvertUsing<UserProfileVMToUserProfileConverter>();
             Mapper.CreateMap<UserProfile, UserProfileViewModel>().ConvertUsing<UserProfileToUserProfileVMConverter>();

             Mapper.CreateMap<ReportViewModel, Report>().ConvertUsing<ReportViewModelToReportConverter>();
             Mapper.CreateMap<Report, ReportViewModel>().ConvertUsing<ReportToReportViewModelConverter>();
         }
    }
}