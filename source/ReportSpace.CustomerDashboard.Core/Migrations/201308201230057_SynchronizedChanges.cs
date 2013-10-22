namespace ReportSpace.CustomerDashboard.Core.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class SynchronizedChanges : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Reports", "Description", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Reports", "Description");
        }
    }
}
