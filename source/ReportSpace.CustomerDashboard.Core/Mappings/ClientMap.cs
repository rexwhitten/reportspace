namespace ReportSpace.CustomerDashboard.Core.Mappings
{
    using System.Data.Entity.ModelConfiguration;

    using ReportSpace.CustomerDashboard.Core.Models;

    public class ClientMap : EntityTypeConfiguration<Client>
    {
        public ClientMap()
        {
            Property(c => c.Id).HasColumnName("FORW_NO").HasColumnType("float");
        }
    }
}