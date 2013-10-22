namespace ReportSpace.CustomerDashboard.Core.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class AddedClientUserTable : DbMigration
    {
        public override void Up()
        {
            this.CreateTable(
                "UserProfileClient",
                c => new
                         {
                             UserProfileId = c.Int(false),
                             ClientId = c.Int(false) 
                         });
        }

        public override void Down()
        {
            this.DropTable("UserProfileClient");
        }
    }
}
