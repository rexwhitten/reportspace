namespace ReportSpace.CustomerDashboard.Core.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class AddLogoFileOnUserProfile : DbMigration
    {
        public override void Up()
        {
            AddColumn("UserProfile", "CompanyLogoFileName", c => c.String());
        }
        
        public override void Down()
        {
            this.DropColumn("UserProfile", "CompanyLogoFileName");
        }
    }
}