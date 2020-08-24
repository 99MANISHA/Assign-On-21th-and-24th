namespace MVCMovieCustWithAuth.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changedintMenberShipTypeId : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Customers", "MenberShipType_Id", "dbo.MenberShipTypes");
            DropIndex("dbo.Customers", new[] { "MenberShipType_Id" });
            RenameColumn(table: "dbo.Customers", name: "MenberShipType_Id", newName: "MenbershipTypeId");
            AlterColumn("dbo.Customers", "MenbershipTypeId", c => c.Int(nullable: false));
            CreateIndex("dbo.Customers", "MenbershipTypeId");
            AddForeignKey("dbo.Customers", "MenbershipTypeId", "dbo.MenberShipTypes", "Id", cascadeDelete: true);
            DropColumn("dbo.Customers", "MembershipTypeId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Customers", "MembershipTypeId", c => c.Int(nullable: false));
            DropForeignKey("dbo.Customers", "MenbershipTypeId", "dbo.MenberShipTypes");
            DropIndex("dbo.Customers", new[] { "MenbershipTypeId" });
            AlterColumn("dbo.Customers", "MenbershipTypeId", c => c.Int());
            RenameColumn(table: "dbo.Customers", name: "MenbershipTypeId", newName: "MenberShipType_Id");
            CreateIndex("dbo.Customers", "MenberShipType_Id");
            AddForeignKey("dbo.Customers", "MenberShipType_Id", "dbo.MenberShipTypes", "Id");
        }
    }
}
