namespace DealershipApi.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatedFullName : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customer", "FullName", c => c.String());
            AddColumn("dbo.SalesPerson", "FullName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.SalesPerson", "FullName");
            DropColumn("dbo.Customer", "FullName");
        }
    }
}
