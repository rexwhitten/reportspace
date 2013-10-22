namespace ReportSpace.CustomerDashboard.Core
{
    using System.Data.Entity;

    using ReportSpace.CustomerDashboard.Core.Models;

    public interface IUserContext
    {
        IDbSet<UserProfile> UserProfiles { get; set; }

        IDbSet<Membership> Memberships { get; set; }

        IDbSet<Client> Clients { get; set; }

        IDbSet<Role> Roles { get; set; }

        int SaveChanges();
    }
}