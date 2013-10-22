namespace ReportSpace.CustomerDashboard.Core.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class AddDateColumnsToUserProfile : DbMigration
    {
        public override void Up()
        {
            this.AddColumn("UserProfile", "Created", cb => cb.DateTime(false, defaultValueSql: "getdate()"));
            this.AddColumn("UserProfile", "Updated", cb => cb.DateTime(false, defaultValueSql: "getdate()"));
        }
        
        public override void Down()
        {
            this.DropColumn("UserProfile", "Created");
            this.DropColumn("UserProfile", "Updated");
        }
    }
}
