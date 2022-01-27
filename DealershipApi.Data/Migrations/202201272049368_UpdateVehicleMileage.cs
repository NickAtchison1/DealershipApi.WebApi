namespace DealershipApi.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateVehicleMileage : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Transaction", "CustomerId", "dbo.Customer");
            DropForeignKey("dbo.Transaction", "SalesPersonId", "dbo.SalesPerson");
            DropIndex("dbo.Transaction", new[] { "CustomerId" });
            DropIndex("dbo.Transaction", new[] { "SalesPersonId" });
            CreateTable(
                "dbo.Supplier",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 100),
                        SupplierType = c.Int(nullable: false),
                        Email = c.String(nullable: false, maxLength: 100),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Transaction", "SupplierId", c => c.Int());
            AddColumn("dbo.Vehicle", "VehicleCondition", c => c.Int(nullable: false));
            AddColumn("dbo.Vehicle", "Mileage", c => c.Int(nullable: false));
            AlterColumn("dbo.Customer", "FirstName", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Customer", "LastName", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Customer", "Address", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.Customer", "Email", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.Dealership", "Name", c => c.String(maxLength: 200));
            AlterColumn("dbo.Dealership", "Address", c => c.String(maxLength: 50));
            AlterColumn("dbo.SalesPerson", "FirstName", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.SalesPerson", "LastName", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.SalesPerson", "Email", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.Transaction", "CustomerId", c => c.Int());
            AlterColumn("dbo.Transaction", "SalesPersonId", c => c.Int());
            AlterColumn("dbo.Vehicle", "Make", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Vehicle", "Model", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Vehicle", "Color", c => c.String(nullable: false, maxLength: 25));
            CreateIndex("dbo.Transaction", "CustomerId");
            CreateIndex("dbo.Transaction", "SalesPersonId");
            CreateIndex("dbo.Transaction", "SupplierId");
            AddForeignKey("dbo.Transaction", "SupplierId", "dbo.Supplier", "Id");
            AddForeignKey("dbo.Transaction", "CustomerId", "dbo.Customer", "Id");
            AddForeignKey("dbo.Transaction", "SalesPersonId", "dbo.SalesPerson", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Transaction", "SalesPersonId", "dbo.SalesPerson");
            DropForeignKey("dbo.Transaction", "CustomerId", "dbo.Customer");
            DropForeignKey("dbo.Transaction", "SupplierId", "dbo.Supplier");
            DropIndex("dbo.Transaction", new[] { "SupplierId" });
            DropIndex("dbo.Transaction", new[] { "SalesPersonId" });
            DropIndex("dbo.Transaction", new[] { "CustomerId" });
            AlterColumn("dbo.Vehicle", "Color", c => c.String(nullable: false));
            AlterColumn("dbo.Vehicle", "Model", c => c.String(nullable: false));
            AlterColumn("dbo.Vehicle", "Make", c => c.String(nullable: false));
            AlterColumn("dbo.Transaction", "SalesPersonId", c => c.Int(nullable: false));
            AlterColumn("dbo.Transaction", "CustomerId", c => c.Int(nullable: false));
            AlterColumn("dbo.SalesPerson", "Email", c => c.String());
            AlterColumn("dbo.SalesPerson", "LastName", c => c.String(nullable: false));
            AlterColumn("dbo.SalesPerson", "FirstName", c => c.String(nullable: false));
            AlterColumn("dbo.Dealership", "Address", c => c.String());
            AlterColumn("dbo.Dealership", "Name", c => c.String());
            AlterColumn("dbo.Customer", "Email", c => c.String(nullable: false));
            AlterColumn("dbo.Customer", "Address", c => c.String(nullable: false));
            AlterColumn("dbo.Customer", "LastName", c => c.String(nullable: false));
            AlterColumn("dbo.Customer", "FirstName", c => c.String(nullable: false));
            DropColumn("dbo.Vehicle", "Mileage");
            DropColumn("dbo.Vehicle", "VehicleCondition");
            DropColumn("dbo.Transaction", "SupplierId");
            DropTable("dbo.Supplier");
            CreateIndex("dbo.Transaction", "SalesPersonId");
            CreateIndex("dbo.Transaction", "CustomerId");
            AddForeignKey("dbo.Transaction", "SalesPersonId", "dbo.SalesPerson", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Transaction", "CustomerId", "dbo.Customer", "Id", cascadeDelete: true);
        }
    }
}
