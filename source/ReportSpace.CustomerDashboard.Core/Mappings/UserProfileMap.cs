namespace ReportSpace.CustomerDashboard.Core.Mappings
{
    using System.Data.Entity.ModelConfiguration;

    using ReportSpace.CustomerDashboard.Core.Models;

    public class UserProfileMap : EntityTypeConfiguration<UserProfile>
    {
        public UserProfileMap()
        {
            HasMany(u => u.Roles).WithMany(u => u.UserProfiles).Map(
                m =>
                {
                    m.ToTable("webpages_UsersInRoles");
                    m.MapLeftKey("UserId");
                    m.MapRightKey("RoleId");
                });

            HasMany(up => up.Clients).WithMany(c => c.Users).Map(
                m =>
                    {
                        m.MapLeftKey("UserProfileId");
                        m.MapRightKey("ClientId");
                        m.ToTable("UserProfileClient");
                    });

            HasRequired(up => up.Membership)
                .WithRequiredPrincipal().WillCascadeOnDelete(true);
        }
    }
}