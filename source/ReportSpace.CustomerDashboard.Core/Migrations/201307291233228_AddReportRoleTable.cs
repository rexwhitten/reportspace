namespace ReportSpace.CustomerDashboard.Core.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class AddReportRoleTable : DbMigration
    {
        public override void Up()
        {
            this.CreateTable(
                "ReportRole",
                c => new
                         {
                             ReportId = c.Int(false), 
                             RoleId = c.Int(false)
                         })
            .ForeignKey("dbo.Reports", t => t.ReportId)
            .ForeignKey("dbo.webpages_Roles", t => t.RoleId);
        }
        
        public override void Down()
        {
            this.DropTable("ReportRole");
        }
    }
}
