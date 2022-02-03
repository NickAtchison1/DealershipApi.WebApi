namespace DealershipApi.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addCreatedandUpdatedBy : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Transaction", "CreatedBy", c => c.String());
            AddColumn("dbo.Transaction", "CreatedDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Transaction", "UpdatedBy", c => c.String());
            AddColumn("dbo.Transaction", "UpdatedDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Vehicle", "CreatedBy", c => c.String());
            AddColumn("dbo.Vehicle", "CreatedDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Vehicle", "UpdatedBy", c => c.String());
            AddColumn("dbo.Vehicle", "UpdatedDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.ApplicationUser", "DealershipId", c => c.Int(nullable: false));
            CreateIndex("dbo.ApplicationUser", "DealershipId");
            AddForeignKey("dbo.ApplicationUser", "DealershipId", "dbo.Dealership", "Id", cascadeDelete: false);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ApplicationUser", "DealershipId", "dbo.Dealership");
            DropIndex("dbo.ApplicationUser", new[] { "DealershipId" });
            DropColumn("dbo.ApplicationUser", "DealershipId");
            DropColumn("dbo.Vehicle", "UpdatedDate");
            DropColumn("dbo.Vehicle", "UpdatedBy");
            DropColumn("dbo.Vehicle", "CreatedDate");
            DropColumn("dbo.Vehicle", "CreatedBy");
            DropColumn("dbo.Transaction", "UpdatedDate");
            DropColumn("dbo.Transaction", "UpdatedBy");
            DropColumn("dbo.Transaction", "CreatedDate");
            DropColumn("dbo.Transaction", "CreatedBy");
        }
    }
}
