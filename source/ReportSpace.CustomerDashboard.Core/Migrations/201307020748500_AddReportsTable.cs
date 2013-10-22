namespace ReportSpace.CustomerDashboard.Core.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddReportsTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Reports",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Category = c.String(),
                        Path = c.String(),
                        Created = c.DateTime(nullable: false, defaultValue: DateTime.UtcNow),
                        Updated = c.DateTime(nullable: false, defaultValue: DateTime.UtcNow),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Reports");
        }
    }
}
