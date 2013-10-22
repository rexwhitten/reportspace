namespace ReportSpace.CustomerDashboard.Web.Services
{
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Web.Security;

    public class RoleService : IRoleService
    {
        public bool IsCurrentUserInRole(string role)
        {
            var rolesForCurrentUser = this.GetRolesForCurrentUser().ToList();
            return rolesForCurrentUser.Any(r => string.Compare(r, role, true, CultureInfo.InvariantCulture) == 0);
        }

        public IList<string> GetRolesForCurrentUser()
        {
            return Roles.GetRolesForUser().ToList();
        }
    }
}