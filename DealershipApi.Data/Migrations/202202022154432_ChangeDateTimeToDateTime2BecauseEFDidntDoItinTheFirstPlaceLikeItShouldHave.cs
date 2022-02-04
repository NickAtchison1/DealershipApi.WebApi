namespace DealershipApi.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeDateTimeToDateTime2BecauseEFDidntDoItinTheFirstPlaceLikeItShouldHave : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Transaction", "CreatedDate", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.Transaction", "UpdatedDate", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.Vehicle", "CreatedDate", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.Vehicle", "UpdatedDate", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Vehicle", "UpdatedDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Vehicle", "CreatedDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Transaction", "UpdatedDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Transaction", "CreatedDate", c => c.DateTime(nullable: false));
        }
    }
}
