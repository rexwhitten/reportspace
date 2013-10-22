namespace ReportSpace.CustomerDashboard.Web.Migrations
{
    using System.Data.Entity.Migrations;
    using System.Linq;
    using System.Web.Security;

    using ReportSpace.CustomerDashboard.Core;

    using WebMatrix.WebData;

    internal sealed class WebConfiguration : DbMigrationsConfiguration<UsersContext>
    {
        private const string AdministratorUsername = "administrator";

        private const string AdministratorPassword = "ReportSpaceadmin";

        private const string AdministratorRole = "Administrator";

        public WebConfiguration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(UsersContext context)
        {
            //  This method will be called after migrating to the latest version.
            WebSecurity.InitializeDatabaseConnection(
                    "DefaultConnection", 
                    "UserProfile", 
                    "UserId", 
                    "UserName", 
                    autoCreateTables: true);

            SeedAdminRole();
            SeedAdminUsername();
            AddAdminUsernameToAdminRole();
        }

        private static void AddAdminUsernameToAdminRole()
        {
            if (!Roles.GetRolesForUser(AdministratorUsername).ToList().Contains(AdministratorRole))
            {
                Roles.AddUsersToRoles(new[] { AdministratorUsername }, new[] { AdministratorRole });
            }
        }

        private static void SeedAdminUsername()
        {
            if (!WebSecurity.UserExists(AdministratorUsername))
            {
                WebSecurity.CreateUserAndAccount(AdministratorUsername, AdministratorPassword);
            }
        }

        private static void SeedAdminRole()
        {
            if (!Roles.RoleExists(AdministratorRole))
            {
                Roles.CreateRole(AdministratorRole);
            }
        }
    }
}
