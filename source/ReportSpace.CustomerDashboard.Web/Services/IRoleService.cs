namespace ReportSpace.CustomerDashboard.Web.Services
{
    using System.Collections.Generic;

    public interface IRoleService
    {
        bool IsCurrentUserInRole(string role);

        IList<string> GetRolesForCurrentUser();
    }
}