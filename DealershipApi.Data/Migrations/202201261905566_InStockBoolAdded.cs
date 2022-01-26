namespace DealershipApi.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InStockBoolAdded : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Vehicle", "InStock", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Vehicle", "InStock");
        }
    }
}
