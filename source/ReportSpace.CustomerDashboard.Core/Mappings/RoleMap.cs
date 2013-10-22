namespace ReportSpace.CustomerDashboard.Core.Mappings
{
    using System.Data.Entity.ModelConfiguration;

    using ReportSpace.CustomerDashboard.Core.Models;

    public class RoleMap : EntityTypeConfiguration<Role>
    {
        public RoleMap()
        {
            HasMany(u => u.UserProfiles).WithMany(u => u.Roles).Map(
                m =>
                {
                    m.ToTable("webpages_UsersInRoles");
                    m.MapLeftKey("RoleId");
                    m.MapRightKey("UserId");
                });
        }
    }
}