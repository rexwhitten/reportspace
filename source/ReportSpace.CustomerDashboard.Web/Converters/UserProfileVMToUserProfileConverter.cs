namespace ReportSpace.CustomerDashboard.Web.Converters
{
    using System.Data.Entity;
    using System.Linq;

    using ReportSpace.CustomerDashboard.Core;
    using ReportSpace.CustomerDashboard.Core.Models;
    using ReportSpace.CustomerDashboard.Core.QueryableExtensions;
    using ReportSpace.CustomerDashboard.Web.ViewModels;

    using AutoMapper;

    public class UserProfileVMToUserProfileConverter : TypeConverter<UserProfileViewModel, UserProfile>
    {
        private readonly IUserContext _userContext;

        public UserProfileVMToUserProfileConverter(IUserContext userContext)
        {
            _userContext = userContext;
        }

        protected override UserProfile ConvertCore(UserProfileViewModel source)
        {
            var destination = source.Id != 0
                ? _userContext.UserProfiles.Include(up => up.Roles).Include(up => up.Clients).First(up => up.Id == source.Id)
                : _userContext.UserProfiles.Create();

            destination.Email = source.Email;
            destination.FirstName = source.FirstName;
            destination.LastName = source.LastName;
            destination.Id = source.Id;
            destination.UserName = source.UserName;
            destination.CompanyLogoFileName = source.CompanyLogoFileName;

            destination.Roles = _userContext.Roles.FilterByListOfIds(source.RoleIds).ToList();
            destination.Clients = _userContext.Clients.FilterByListOfIds(source.ClientIds).ToList();

            return destination;
        }
    }
}