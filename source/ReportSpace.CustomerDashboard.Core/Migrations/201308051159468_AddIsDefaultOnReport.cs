namespace ReportSpace.CustomerDashboard.Core.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class AddIsDefaultOnReport : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Reports", "IsDefault", c => c.Boolean(nullable: false, defaultValue: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Reports", "IsDefault");
        }
    }
}
