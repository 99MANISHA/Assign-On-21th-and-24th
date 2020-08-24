namespace MVCMovieCustWithAuth.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initialmigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MenberShipTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SignUpFree = c.Short(nullable: false),
                        DurationInMonths = c.Byte(nullable: false),
                        DiscountRate = c.Byte(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Customers", "MembershipTypeId", c => c.Int(nullable: false));
            AddColumn("dbo.Customers", "MenberShipType_Id", c => c.Int());
            CreateIndex("dbo.Customers", "MenberShipType_Id");
            AddForeignKey("dbo.Customers", "MenberShipType_Id", "dbo.MenberShipTypes", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Customers", "MenberShipType_Id", "dbo.MenberShipTypes");
            DropIndex("dbo.Customers", new[] { "MenberShipType_Id" });
            DropColumn("dbo.Customers", "MenberShipType_Id");
            DropColumn("dbo.Customers", "MembershipTypeId");
            DropTable("dbo.MenberShipTypes");
        }
    }
}
