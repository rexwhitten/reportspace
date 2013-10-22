namespace ReportSpace.CustomerDashboard.Core
{
    using System.Data.Entity;
    using System.Reflection;

    using ReportSpace.CustomerDashboard.Core.Models;

    public class UsersContext : DbContext, IUserContext
    {
        public UsersContext()
            : base("DefaultConnection")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Configurations.AddFromAssembly(Assembly.GetExecutingAssembly());
        }
 
        public IDbSet<UserProfile> UserProfiles { get; set; }

        public IDbSet<Membership> Memberships { get; set; }

        public IDbSet<Client> Clients { get; set; }

        public IDbSet<Role> Roles { get; set; }
    }
}