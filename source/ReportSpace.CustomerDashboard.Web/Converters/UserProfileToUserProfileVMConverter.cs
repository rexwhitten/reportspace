namespace ReportSpace.CustomerDashboard.Web.Converters
{
    using System.Linq;

    using ReportSpace.CustomerDashboard.Core.Models;
    using ReportSpace.CustomerDashboard.Web.ViewModels;

    using AutoMapper;

    public class UserProfileToUserProfileVMConverter : TypeConverter<UserProfile, UserProfileViewModel>
    {
        protected override UserProfileViewModel ConvertCore(UserProfile source)
        {
            
            var destination = new UserProfileViewModel
                                  {
                                      Id = source.Id,
                                      UserName = source.UserName,
                                  };

            return destination;
        }
    }
}