namespace DealershipApi.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveDealerFromApplicationUser : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ApplicationUser", "DealershipId", "dbo.Dealership");
            DropIndex("dbo.ApplicationUser", new[] { "DealershipId" });
            DropColumn("dbo.ApplicationUser", "DealershipId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ApplicationUser", "DealershipId", c => c.Int(nullable: false));
            CreateIndex("dbo.ApplicationUser", "DealershipId");
            AddForeignKey("dbo.ApplicationUser", "DealershipId", "dbo.Dealership", "Id", cascadeDelete: true);
        }
    }
}
