namespace DealershipApi.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddVehicleName : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Vehicle", "VehicleName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Vehicle", "VehicleName");
        }
    }
}
