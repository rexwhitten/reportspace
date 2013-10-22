namespace ReportSpace.CustomerDashboard.Core.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class AddIsHiddenColumnToReport : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Reports", "IsHidden", c => c.Boolean(nullable: false, defaultValue: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Reports", "IsHidden");
        }
    }
}
