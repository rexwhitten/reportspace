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
                ? _userContext.UserProfiles.First(up => up.Id == source.Id)
                : _userContext.UserProfiles.Create();

            destination.Id = source.Id;
            destination.UserName = source.UserName;

            return destination;
        }
    }
}