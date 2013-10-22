namespace ReportSpace.CustomerDashboard.Core.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class AddExtraFieldsOnUserProfile : DbMigration
    {
        public override void Up()
        {
            this.AddColumn("dbo.UserProfile", "FirstName", c => c.String());
            this.AddColumn("dbo.UserProfile", "LastName", c => c.String());
            this.AddColumn("dbo.UserProfile", "Email", c => c.String());   
        }
        
        public override void Down()
        {
            this.DropColumn("dbo.UserProfile", "Email");
            this.DropColumn("dbo.UserProfile", "LastName");
            this.DropColumn("dbo.UserProfile", "FirstName");
        }
    }
}
