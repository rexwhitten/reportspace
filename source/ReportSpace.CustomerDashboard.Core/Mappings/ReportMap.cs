namespace ReportSpace.CustomerDashboard.Core.Mappings
{
    using System.Data.Entity.ModelConfiguration;

    using ReportSpace.CustomerDashboard.Core.Models;

    public class ReportMap : EntityTypeConfiguration<Report>
    {
        public ReportMap()
        {
            HasMany(u => u.Roles).WithMany(u => u.Reports).Map(
                m =>
                {
                    m.ToTable("ReportRole");
                    m.MapLeftKey("ReportId");
                    m.MapRightKey("RoleId");
                });
        }
    }
}