namespace ReportSpace.CustomerDashboard.Core.Migrations
{
    using System.Data.Entity.Migrations;

    public class CoreConfiguration : DbMigrationsConfiguration<ReportsContext>
    {
        public CoreConfiguration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(ReportsContext context)
        {
        }
    }
}
