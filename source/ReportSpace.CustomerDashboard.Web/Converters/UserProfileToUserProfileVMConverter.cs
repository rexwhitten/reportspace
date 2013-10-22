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
                                      Email = source.Email,
                                      FirstName = source.FirstName,
                                      LastName = source.LastName,
                                      Id = source.Id,
                                      UserName = source.UserName,
                                      CompanyLogoFileName = source.CompanyLogoFileName,
                                      IsConfirmed = source.Membership.IsConfirmed,
                                      Clients = string.Join(",", source.Clients.Select(c => string.Format("{0};{1}", c.Id, c.Name)).ToArray()),
                                      Roles = string.Join(",", source.Roles.Select(r => string.Format("{0};{1}", r.Id, r.Name)).ToArray())
                                  };

            return destination;
        }
    }
}